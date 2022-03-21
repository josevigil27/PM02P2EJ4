using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PM02P2EJ4.Models;
using System.Threading.Tasks;

namespace PM02P2EJ4.Controllers
{
    public class VideoDB
    {
        readonly SQLiteAsyncConnection db;

        public VideoDB (string pathbasedatos)
        {
            db = new SQLiteAsyncConnection(pathbasedatos);
            db.CreateTableAsync<Video>().Wait();
        }

        public Task<List<Video>> GetVideoList()
        {
            return db.Table<Video>().ToListAsync();
        }

        public Task<Video> ObtenerVideoPorId(int vcodigo)
        {
            return db.Table<Video>()
                .Where(i => i.Id == vcodigo)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveVideo(Video videos)
        {
            if (videos.Id != 0)
            {
                return db.UpdateAsync(videos);
            }
            else
            {
                return db.InsertAsync(videos);
            }
        }

        public Task<int> DeleteVideo(Video videos)
        {
            return db.DeleteAsync(videos);
        }
    }
}
