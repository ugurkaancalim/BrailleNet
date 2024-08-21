using BrailleNet.Readers.Interfaces;

namespace BrailleNet.Readers.Strategies
{
    public class TxtReadStrategy : IReaderStrategy, IDisposable
    {
        private StreamReader? _fileReader;
        private bool _disposed = false;

        public bool Load(string filePath)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(TxtReadStrategy));
            }

            DisposeStreamReader();

            _fileReader = new StreamReader(filePath);
            return true;

        }
        private void DisposeStreamReader()
        {
            _fileReader?.Dispose();
            _fileReader = null;
        }
        public string? ReadLine()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(TxtReadStrategy));
            }

            return _fileReader?.ReadLine();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _fileReader?.Dispose();
                }

                _disposed = true;
            }
        }

        ~TxtReadStrategy()
        {
            Dispose(false);
        }
    }

}
