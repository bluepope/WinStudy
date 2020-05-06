using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp1.Test
{
    class PostgreSqlBulkInsertTest
    {
        public void Run()
        {
            var dataList = new List<string>();

            //우편번호 DB 다운로드하여 경기도 98만건으로 테스트해봄
            //https://www.epost.go.kr/search/zipcode/areacdAddressDown.jsp
            var filePath = $"{AppDomain.CurrentDomain.BaseDirectory}/Testfile/20200506_경기도.txt";

            using (var sr = new StreamReader(filePath))
            {
                var totalString = sr.ReadToEnd().Split('\n');

                foreach(var str in totalString)
                {
                    dataList.Add(str);
                }
            }


            //postgresql 접속
            using (var conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;Database=dbname;User Id=idid;Password=pwpw;"))
            {
                int maxCnt = dataList.Count;

                conn.Open();

                //bulk insert
                //https://www.npgsql.org/doc/copy.html
                //COPY 테이블명 (컬럼명) FROM STDIN (FORMAT BINARY)
                using (var writer = conn.BeginBinaryImport("COPY test (col1) FROM STDIN (FORMAT BINARY)"))
                {
                    var sw = new Stopwatch();

                    Console.WriteLine($"{maxCnt}개 시작");
                    sw.Start();

                    foreach (var item in dataList)
                    {
                        //1줄 추가 - Insert 라고 생각하면됨
                        writer.WriteRow(item);
                        //writer.WriteRow("", 1, 0.1); //params object[] 로 들어감
                    }

                    //다 끝나면 완료처리해야 커밋됨
                    writer.Complete();

                    sw.Stop();
                    Console.WriteLine(sw.Elapsed.ToString());
                }
            }
        }
    }
}
