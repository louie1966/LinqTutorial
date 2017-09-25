﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Introduction {
    class Program {
        static void Main(string[] args) {
            string path = @"C:\windows";
            ShowLargeFilesWithoutLinq(path);
            Console.WriteLine("***");
            ShowLargeFilesWithLinq(path);
            //Console.ReadKey();
        }

        // Show 5 biggest files without LINQ
        private static void ShowLargeFilesWithoutLinq(string path) {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());
            for (int i = 0; i < 5; i++) {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name,-20} : { file.Length,10:N0}");
            }
        }

        // Show 5 biggest files with LINQ
        private static void ShowLargeFilesWithLinq(string path) {
            var query = new DirectoryInfo(path).GetFiles()
                        .OrderByDescending(f => f.Length)
                        .Take(5);

            foreach (var file in query) {
                Console.WriteLine($"{file.Name,-20} : { file.Length,10:N0}");
            }
        }
    }
}