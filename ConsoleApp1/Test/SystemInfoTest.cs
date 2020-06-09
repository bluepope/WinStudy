using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace ConsoleApp1.Test
{
    class SystemInfoTest
    {
        /// <summary>
        /// 메인보드 고유 값
        /// </summary>
        /// <returns>메인보드 고유값</returns>
        private string GetMainBoardUUID()
        {
            var list = new ManagementObjectSearcher("SELECT UUID FROM Win32_ComputerSystemProduct").Get();

            foreach (var obj in list)
            {
                return obj.GetPropertyValue("UUID").ToString();
            }

            return null;
        }
        
        /// <summary>
        /// CPU ID
        /// </summary>
        /// <returns>CPU ID</returns>
        private string GetCpuId()
        {
            var list = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor").Get();

            foreach (var obj in list)
            {
                return obj.GetPropertyValue("ProcessorId").ToString();
            }

            return null;
        }
    
    
        public void Run()
        {
            Console.WriteLine(GetMainBoardUUID());
            Console.WriteLine(GetCpuId());
        }
    }
}
