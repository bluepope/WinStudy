using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mp3AutoPlayer.Models
{
    public class Mp3Player
    {
        private Mp3FileReader _reader;
        private DirectSoundOut _sOut = new DirectSoundOut();

        public PlaybackState PlayStatus { get { return _sOut.PlaybackState; } }

        public int Length
        {
            get
            {
                try
                {
                    return (int)_reader.TotalTime.TotalMilliseconds;
                }
                catch
                {
                    return 0;
                }
            }
        }

        // 현재 재생지점(경과 시간)을 얻는 메소드 (반환값 : 밀리세컨드)
        public int Position
        {
            get
            {
                try
                {
                    return (int)_reader.CurrentTime.TotalMilliseconds;
                }
                catch
                {
                    return 0;
                }
            }
        }

        // 현재 재생지점(경과 시간)을 얻는 메소드 (반환값 : TimeSpan)
        public TimeSpan CurrentTime
        {
            get
            {
                return _reader.CurrentTime;
            }
            set
            {
                _reader.CurrentTime = value;
            }
        }

        public TimeSpan TotalTime
        {
            get
            {
                return _reader.TotalTime;
            }
        }

        public event EventHandler PlayEnded;

        public Mp3Player()
        {
            _sOut.PlaybackStopped += PlayBackStopped;
            _sOut.Volume = 1.0F;
        }

        #region MP3 플레이어 기능 메소드
        // 파일 열기
        public void Play(string fileName)
        {
            if (_reader != null)
            {
                if (_sOut.PlaybackState == PlaybackState.Playing)
                    _sOut.Stop();

                _reader.Dispose();
            }

            if (_sOut.PlaybackState != PlaybackState.Paused)
            {
                _reader = new Mp3FileReader(fileName);
                _sOut.Init(_reader);
            }

            _sOut.Play();
        }

        // 음악 일시정지
        public void Pause()
        {
            if (_sOut.PlaybackState == PlaybackState.Playing) //음악을 재생(Play()를 호출)하기전에 Pause(), Stop()를 호출하면, 그 후에 음악 재생이 안됨
                _sOut.Pause();
        }

        // 음악 정지 (재생지점을 0으로 초기화)
        public void Stop()
        {
            if (_sOut.PlaybackState == PlaybackState.Playing
                || _sOut.PlaybackState == PlaybackState.Paused) //음악을 재생(Play()를 호출)하기전에 Pause(), Stop()를 호출하면, 그 후에 음악 재생이 안됨
            {
                _sOut.Stop();
            }
            _reader.Position = 0;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }

        // 재생지점을 설정하는 메소드
        public void Seek(int position)
        {
            _reader.CurrentTime = TimeSpan.FromMilliseconds(position);
        }
        #endregion

        // 음악이 다 재생되면 호출되는 메소드
        private void PlayBackStopped(object sender, StoppedEventArgs e)
        {
            if ((int)_reader.TotalTime.TotalSeconds <= (int)_reader.CurrentTime.TotalSeconds + 1)
                PlayEnded?.Invoke(sender, e);
        }
    }
}
