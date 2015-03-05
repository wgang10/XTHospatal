using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace WinFormAppTest
{
    public class clsSubThread : IDisposable
    {
        private Thread thdSubThread = null;
        private Mutex mUnique = new Mutex();
 
        private bool blnIsStopped;
        private bool blnSuspended;
        private bool blnStarted;
        private int nStartNum;
 
        public bool IsStopped
        {
            get{ return blnIsStopped; }
        }

        public bool IsSuspended
        {
            get{ return blnSuspended; }
        }

        public int ReturnValue
        {
            get{ return nStartNum;}
        } 
   
        public clsSubThread( int StartNum )
        {
            //
            // TODO: Add constructor logic here
            //
            blnIsStopped = true;
            blnSuspended = false;
            blnStarted = false;
           
            nStartNum = StartNum;
        }
 
        /// <summary>
        /// Start sub-thread
        /// </summary>
        public void Start()
        {
            if( !blnStarted )
            {
                thdSubThread = new Thread( new ThreadStart( SubThread ) );
                blnIsStopped = false;
                blnStarted = true;
                thdSubThread.Start();
            }
        }
 
        /// <summary>
        /// Thread entry function
        /// </summary>
        private void SubThread()
        {
            do
            {
                // Wait for resume-command if got suspend-command here 
                mUnique.WaitOne();
                mUnique.ReleaseMutex();
 
                nStartNum++;
           
                Thread.Sleep(1000); // Release CPU here
            }while( blnIsStopped == false );
        }
 
        /// <summary>
        /// Suspend sub-thread
        /// </summary>
        public void Suspend()
        {
            if( blnStarted && !blnSuspended )
            {
                blnSuspended = true;
                mUnique.WaitOne();
            }
        }
   
        /// <summary>
        /// Resume sub-thread
        /// </summary>
        public void Resume()
        {
            if( blnStarted && blnSuspended )
            {
                blnSuspended = false;
                mUnique.ReleaseMutex();
            }
        }
 
        /// <summary>
        /// Stop sub-thread
        /// </summary>
        public void Stop()
        {
            if( blnStarted )
            {
                if( blnSuspended )
                    Resume();
 
                blnStarted = false;
                blnIsStopped = true;
                thdSubThread.Join();
            }
        }
        #region IDisposable Members
        /// <summary>
        /// Class resources dispose here
        /// </summary>
        public void Dispose()
        {
            // TODO:  Add clsSubThread.Dispose implementation
            Stop();//Stop thread first
            GC.SuppressFinalize( this );
        }
 
        #endregion
    }
}
