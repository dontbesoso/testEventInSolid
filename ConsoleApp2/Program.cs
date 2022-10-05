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

namespace ConsoleApp2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.ISEApplicationEvents_Event applicationEvents;

            try
            {
                application = (SolidEdgeFramework.Application)Marshal.GetActiveObject("SolidEdge.Application");
                application.Visible = true;
                
                applicationEvents = (SolidEdgeFramework.ISEApplicationEvents_Event)application.ApplicationEvents;
                
                applicationEvents.AfterDocumentPrint += ISEApplicationEvents_AfterDocumentPrint;
                applicationEvents.BeforeDocumentPrint += ISEApplicationEvents_BeforeDocumentPrint;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }

        private static void ISEApplicationEvents_AfterDocumentPrint(object theDocument, int hDC, ref double ModelToDC, ref int Rect)
        {
            Console.WriteLine("Po drukowaniu");
        }

        private static void ISEApplicationEvents_BeforeDocumentPrint(object theDocument, int hDC, ref double ModelToDC, ref int Rect)
        {
            Console.WriteLine("Przed drukowaniem");
        }
    }
}
