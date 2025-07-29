namespace Test_2
{
    using System;
    using System.Threading;

    public static class Server
    {
        private static int count = 0;

        // Блокировка для управления параллельным доступом
        private static ReaderWriterLockSlim locker = new ReaderWriterLockSlim();

        // Метод чтения count (много читателей одновременно)
        public static int GetCount()
        {
            locker.EnterReadLock();
            try
            {
                return count;
            }
            finally
            {
                locker.ExitReadLock();
            }
        }

        // Метод добавления значения к count (писатели — по одному)
        public static void AddToCount(int value)
        {
            locker.EnterWriteLock();
            try
            {
                count += value;
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }
    }

}
