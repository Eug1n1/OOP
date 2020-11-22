using System;
using System.Threading;
using ProgressBar = ProgressBar.ProgressBar;

namespace lab_9
{
    public class User
    {
        public event Action MoveComplete = null;
        public event Action CompressComplete = null;

        private global::ProgressBar.ProgressBar progressBar;

        public User()
        {
            progressBar = new global::ProgressBar.ProgressBar();
        }

        public void Move()
        {
            progressBar.Start("Moving progress");
            for (int i = 0; i <= 5; i++)
            {
                Thread.Sleep(800);
                progressBar.Percentage += 20;
            }

            MoveComplete?.Invoke();
        }

        public void Compress()
        {
            progressBar.Start("Compressing progress");
            for (int i = 0; i <= 10; i++)
            {
                Thread.Sleep(600);
                progressBar.Percentage += 10;
            }

            CompressComplete?.Invoke();
        }
    }
}