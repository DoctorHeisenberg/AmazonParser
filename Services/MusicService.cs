using HtmlAgilityPack;
using MusConv.Models;
using MusConv.Services.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusConv.Services
{
    public class MusicService : IMusicService
    {
        public Playlist GetPlaylist(string url)
        {
            using (ChromeDriver driver = new ChromeDriver("D:\\IT\\chromedriver_win32"))
            {
                driver.Navigate().GoToUrl(url);

                Thread.Sleep(2000);
                var page = driver.PageSource;


                HtmlDocument htmlDoc = new();
                htmlDoc.LoadHtml(page);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(driver => driver.FindElement(By.TagName("music-detail-header")));

                var headerPage = htmlDoc.DocumentNode.SelectSingleNode("//music-detail-header");
                var songsClass = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='ReactVirtualized__Grid__innerScrollContainer']");
                var countOfSongs = int.Parse(headerPage.GetAttributeValue("tertiary-text", "0").Split(" ").First());

                var songs = new ObservableCollection<Song>();

                for (int i = 0; i < countOfSongs; i++)
                {
                    try
                    {
                        var songInfo = songsClass.SelectNodes("//music-image-row")[i];
                        var song = new Song
                        {
                            Name = songInfo.GetAttributeValue("primary-text", "No song name"),
                            ArtistName = songInfo.GetAttributeValue("secondary-text-1", "No artist name"),
                            AlbumName = songInfo.GetAttributeValue("secondary-text-2", "No album name"),
                            Duration = songsClass.SelectNodes("//div[@class='col4']")[i].FirstChild.GetAttributeValue("title", "No duration")
                        };
                        songs.Add(song);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }

                var playlist = new Playlist
                {
                    PlaylistInfo = new PlaylistInfo
                    {
                        Name = headerPage.GetAttributeValue("headline", "No name"),
                        Avatar = headerPage.GetAttributeValue("image-src", "No image"),
                        Description = headerPage.GetAttributeValue("secondary-text", "No description")
                    },
                    Songs = songs
                };

                return playlist;
            }
        }


    }
}
