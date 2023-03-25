using System;
using System.Collections.Generic;
using System.IO;
using IronPython.Hosting;
using IronPython.Runtime;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting.Runtime;

namespace ClusteringComplex.TestPython
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string expression = @"import datetime 
print(datetime.datetime.now())";

            var engine = Python.CreateEngine();
         //   var source = engine.CreateScriptSourceFromString(expression);
          //  var scope = engine.CreateScope();
         //   source.Execute(scope);

           /*ICollection<string> paths = p1.GetSearchPaths();
            string dir = @"C:\abc";
            paths.Add(dir);
            p1.SetSearchPaths(paths);
            try
            {
                engine.ImportModule("datetime");
                engine.ExecuteFile("C:\\Users\\Tatya\\OneDrive\\Рабочий стол\\магистратура\\магистерская\\2 курс\\Python\\test.py");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/
            string _path = @"C:\PythonC";
            ScriptEngine _engine;

            var opts = new Dictionary<string, object>();
            opts["Frames"] = ScriptingRuntimeHelpers.True;
            opts["Debug"] = ScriptingRuntimeHelpers.True;
            _engine = Python.CreateEngine(opts);

            var sp = _engine.GetSearchPaths();
            //sp.Add(@"c:\Program Files\IronPython 2.7");
            //sp.Add(@"c:\Program Files\IronPython 2.7\DLLs");
            //sp.Add(@"c:\Program Files\IronPython 2.7\Lib");
            //sp.Add(@"c:\Program Files\IronPython 2.7\Lib\site-packages");

            //sp.Add(@"C:\Users\Tatya\PycharmProjects\Diploma_Practice\venv");
            //sp.Add(@"C:\Users\Tatya\PycharmProjects\Diploma_Practice\venv\DLLs");
            //sp.Add(@"C:\Users\Tatya\PycharmProjects\Diploma_Practice\venv\Lib");
            //sp.Add(@"C:\Users\Tatya\PycharmProjects\Diploma_Practice\venv\Lib\site-packages");

            sp.Add(@"c:\Python310");
            sp.Add(@"c:\Python310\DLLs");
            sp.Add(@"c:\Python310\Lib");
            sp.Add(@"c:\Python310\Lib\site-packages");
            sp.Add(@"C:\Users\Tatya\AppData\Roaming\Python\Python310\site-packages");
            sp.Add(_path);
            _engine.SetSearchPaths(sp);

            var _runtime = _engine.Runtime;
            var scope = _runtime.ExecuteFile(Path.Combine(_path, "test.py"));

            Console.ReadLine();
        }
    }
}
