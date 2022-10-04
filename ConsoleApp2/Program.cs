using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using System.Threading;
using System.Reflection;
//using SolidEdge.ApplicationEvents.Properties;

namespace ConsoleApp2
{
    class Program
    {
        //private static SynchronizationContext _uiContext;
        
        static void Main(string[] args)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Application _application = null;
            SolidEdgeFramework.ISEApplicationEvents_Event _applicationEvents;

            //SolidEdgeFramework.ISEAccelerators accelerator = null;

            //_uiContext = SynchronizationContext.Current;

            try
            {
                application = (SolidEdgeFramework.Application)Marshal.GetActiveObject("SolidEdge.Application");
                application.Visible = true;
                
                _applicationEvents = (SolidEdgeFramework.ISEApplicationEvents_Event)application.ApplicationEvents;
                
                _applicationEvents.AfterDocumentPrint += ISEApplicationEvents_AfterDocumentPrint;
                _applicationEvents.BeforeDocumentPrint += ISEApplicationEvents_BeforeDocumentPrint;

                //ConnectApplicationEvents();

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadKey();

        }

        private static void ISEApplicationEvents_AfterDocumentPrint(object theDocument, int hDC, ref double ModelToDC, ref int Rect)
        {
            //LogEvent(MethodInfo.GetCurrentMethod(), new object[] { theDocument, hDC, ModelToDC, Rect });
            Console.WriteLine("Po drukowaniu");
        }

        private static void ISEApplicationEvents_BeforeDocumentPrint(object theDocument, int hDC, ref double ModelToDC, ref int Rect)
        {
            //LogEvent(MethodInfo.GetCurrentMethod(), new object[] { theDocument, hDC, ModelToDC, Rect });
            Console.WriteLine("Przed drukowaniem");
        }
    }
}
