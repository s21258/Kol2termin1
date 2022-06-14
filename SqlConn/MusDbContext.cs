using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kol2termin1.SqlConn
{
    public class MusDbContext : DbContext
    {
        

                public DbSet<Album> Albums {get; set;}
                public DbSet<MusicLabel> MusicLabels {get; set;}
                


        public MusDbContext(DbContextOptions options):base(options){
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var musicians = new List<Musician>{
                new Musician{
                    IdMusician =1,
                    FirstName = "Karol",
                    LastName = "Kowalski",
                    Nickname = "robak"
                    },
                new Musician{
                    IdMusician =2,
                    FirstName = "Robert",
                    LastName = "Lewandowski",
                    Nickname = "bobek"
                    }
            };


            modelBuilder.Entity<Musician>(e=>{
                e.HasKey(e=>e.IdMusician);
                e.Property(e=>e.FirstName).HasMaxLength(30).IsRequired();
                e.Property(e=>e.LastName).HasMaxLength(50).IsRequired();
                e.Property(e=>e.Email).HasMaxLength(20).IsRequired(false);
                
                e.HasData(musicians);
                e.ToTable("Musician");
            });
                modelBuilder.Entity<MusicLabel>(e=>{
                e.HasKey(e=>e.IdMusicLabel);
                e.Property(e=>e.Name).HasMaxLength(50).IsRequired();
                
                e.ToTable("MusicLabel");
            });
                modelBuilder.Entity<Album>(e=>{
                e.HasKey(e=>e.IdAlbum);
                e.Property(e=>e.AlbumName).HasMaxLength(30).IsRequired();
                e.Property(e=>e.PublishDate).IsRequired();
                
                e.HasOne(e=>e.MusicLabel).WithMany(e=>e.Albums).HasForeignKey(e=>e.IdMusicLabel).OnDelete(DeleteBehavior.Cascade);
                
                e.ToTable("Albums");
                });

                modelBuilder.Entity<Track>(e=>{
                e.HasKey(e=>e.IdTrack);
                e.Property(e=>e.TrackName).HasMaxLength(20).IsRequired();
                e.Property(e=>e.Duration).IsRequired();
                
                e.HasOne(e=>e.Album).WithMany(e=>e.Tracks).HasForeignKey(e=>e.IdAlbum).OnDelete(DeleteBehavior.Cascade);
                
                e.ToTable("Tracks");
                });
                
                modelBuilder.Entity<Musician_Track>(e=>{
                e.HasOne(e=>e.Musician).WithMany(e=>e.Tracks).HasForeignKey(e=>e.IdMusician).OnDelete(DeleteBehavior.Cascade);
                e.HasOne(e=>e.Track).WithMany(e=>e.Musicians).HasForeignKey(e=>e.IdTrack).OnDelete(DeleteBehavior.Cascade);
                e.ToTable("Musician_Track");
            });
        }
    }
}