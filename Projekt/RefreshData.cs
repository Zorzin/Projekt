using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Projekt
{
    static class RefreshData
    {
        private static DbConnect _db = new DbConnect();

        public static void Execute()
        {
            DispatcherTimer timer = new DispatcherTimer();
            RefreshList();
            timer.Tick += new EventHandler(Refresh);
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Start();
        }

        static void Refresh(object sender, EventArgs e)
        {
            RefreshList();
        }

        static void RefreshList()
        {
            int count = Lists.ActualTracks.Count;
            for(int i =count-1;i>=0;i--)
            {
                var dt = DateTime.Now;
                dt = dt.AddMilliseconds(-dt.Millisecond);
                dt = dt.AddSeconds(-dt.Second);
                dt = dt.AddTicks(-dt.Ticks % 10000000);
                var tracks = Lists.ActualTracks[i];
                if (tracks.EndHour < dt)
                {
                    if (tracks.Driver!=null)
                    {
                        if (tracks.Driver.Actualbus!=null)
                        {
                            tracks.Driver.Actualbus.Actualdriver = null;
                            tracks.Driver.Actualbus.Actualline = null;
                        }
                        tracks.Driver.Actualbus = null;
                    }
                    Lists.ActualTracks.Remove(tracks);
                }

                if (tracks.StartHour <= dt && tracks.EndHour >= dt)
                {
                    if (tracks.Driver != null)
                    {
                        if (tracks.Driver.Actualbus == null)
                        {
                            if (tracks.Smallbus)
                            {
                                try
                                {
                                    tracks.Driver.Actualbus =
                                    Lists.Buses.First(
                                        x =>
                                            x.Actualdriver == null && x.Actualline == null && x.Type == "small" &&
                                            x.Techcondition == "good");
                                }
                                catch (Exception)
                                {
                                    tracks.Driver.Actualbus = null;
                                }
                                
                            }
                            else
                            {
                                try
                                {
                                    tracks.Driver.Actualbus =
                                    Lists.Buses.First(
                                        x =>
                                            x.Actualdriver == null && x.Actualline == null && x.Type == "big" &&
                                            x.Techcondition == "good");
                                }
                                catch (Exception)
                                {

                                    tracks.Driver.Actualbus = null;
                                }
                                
                            }
                            tracks.Driver.Actualbus.Actualline = tracks.Line;
                            tracks.Driver.Actualbus.Actualdriver = tracks.Driver;
                        }
                    }
                    else
                    {
                        Lists.ActualTracks.Remove(tracks);
                    }
                }
            }
        }
    }
}
