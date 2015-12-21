namespace JustGoApp.DbContextSQLitee
{
    using SQLite.Net;
    using SQLite.Net.Async;
    using SQLite.Net.Platform.WinRT;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Windows.Storage;
    public static class DbContextSQL
    {
        
        public static SQLiteAsyncConnection GetDbConnectionAsync()
        {
            var dbFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "JustGoApp.sqlite");

            var connectionFactory =
                new Func<SQLiteConnectionWithLock>(
                    () =>
                    new SQLiteConnectionWithLock(
                        new SQLitePlatformWinRT(),
                        new SQLiteConnectionString(dbFilePath, storeDateTimeAsTicks: false)));

            var asyncConnection = new SQLiteAsyncConnection(connectionFactory);

            return asyncConnection;
        }

        public static async void InitAsync()
        {
            var connection = GetDbConnectionAsync();
            await connection.CreateTableAsync<User>();
        }

        public static async Task<int> InsertUserAsync(User item)
        {
            var connection = GetDbConnectionAsync();
            var result = await connection.InsertAsync(item);
            return result;
        }

        public static async Task<List<User>> GetUserAsync(User item)
        {
            var connection = GetDbConnectionAsync();
            AsyncTableQuery<User> query = connection.Table<User>().Where(x => x.UserName.Contains(item.UserName));
            List<User> test = await query.ToListAsync();
            return test;
        }

        public static async Task<User> GetUser()
        {
            var connection = GetDbConnectionAsync();

            AsyncTableQuery<User> query = connection.Table<User>();
            var result = await query.FirstOrDefaultAsync(); //ToListAsync();

            return result;
        }

        public static async void DeleteAsync()
        {
            var connection = GetDbConnectionAsync();
            await connection.DeleteAllAsync<User>();
        }
    }
}
