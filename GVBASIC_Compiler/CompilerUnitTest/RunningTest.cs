﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GVBASIC_Compiler.Compiler;
using GVBASIC_Compiler;

namespace CompilerUnitTest
{
    [TestClass]
    public class RunningTest
    {
        [TestMethod]
        public void AssignVar()
        {
            string sourceCode =
                "10 A = 1                               \n" +
                "20 B% = 2                              \n" +
                "30 C$ = \"HJB\"                        \n" +
                "40 D% = 17.1                           \n" +
                "50 EF% = 20.1                          \n" +
                "60 PRINT EF%                           \n" +
                "70 PRINT A                             \n" +
                "80 PRINT C$                            \n" +
                "90 PRINT A + B% + C$ + D%              \n" +
                "100 LET V = 176                        \n" +
                "110 PRINT V                            \n";

            // 20
            // 1
            // HJB
            // 3HJB17
            // 176

            string result =
                "20\n" +
                "1\n" +
                "HJB\n" +
                "3HJB17\n" +
                "176\n";

            TestHelper.TestProgram(sourceCode, result);
        }

        [TestMethod]
        public void ReadData()
        {
            string sourceCode =
                "10 DATA 1,23,2.6,19.5                     \n" +
                "20 READ A,T,F% , R%                       \n" +
                "30 PRINT T,A,F%, R%                       \n";

            // 23
            // 1
            // 2
            // 19

            string result =
                "23" + "\n" +
                "1" + "\n" +
                "2" + "\n" +
                "19" + "\n";

            TestHelper.TestProgram(sourceCode, result);
        }

        [TestMethod]
        public void IfElse()
        {
            string sourceCode =
                "10 A = 1: B = 7                            \n" +
                "20 IF A > 0 THEN PRINT \"A>0\"             \n" +
                "30 IF B < 5 THEN PRINT \"B<5\"             \n" +
                "40 C = 110                                 \n" +
                "50 IF C < 20 GOTO 70 ELSE PRINT \"CCC\"    \n" +
                "60 PRINT \"THIS IS 60\"                    \n" +
                "70 PRINT \"THIS IS 70\"                    \n" +
                "80 END                                     \n" +
                "90 PRINT 117                               ";

            // A>0
            // CCC
            // THIS IS 60
            // THIS IS 70

            string result =
                "A>0" + "\n" +
                "CCC" + "\n" +
                "THIS IS 60" + "\n" +
                "THIS IS 70" + "\n";

            TestHelper.TestProgram(sourceCode, result);
        }

        [TestMethod]
        public void ForNext()
        {
            string sourceCode =
                "10 FOR I=1 TO 5                            \n" +
                "20 FOR J=I TO 3                            \n" +
                "30 PRINT J;                                \n" +
                "40 NEXT                                    \n" +
                "45 PRINT \";\"                             \n" +
                "50 NEXT                                    \n";

            // 123;
            // 23;
            // 3;
            // 4;
            // 5;

            string result =
                "123;"      + "\n" +
                "23;"       + "\n" +
                "3;"        + "\n" +
                "4;"        + "\n" +
                "5;"        + "\n";

            TestHelper.TestProgram(sourceCode, result);
        }

        [TestMethod]
        public void GOTO()
        {
            string sourceCode =
                "10 A = 1                            \n" +
                "20 PRINT A                          \n" +
                "30 A = A + 1                        \n" +
                "40 IF A<5 GOTO 20                   \n";

            // 1
            // 2
            // 3
            // 4

            string result =
                "1" + "\n" +
                "2" + "\n" +
                "3" + "\n" +
                "4" + "\n";

            TestHelper.TestProgram(sourceCode, result);
        }

        [TestMethod]
        public void WhileWend()
        {
            string sourceCode =
                "10 A = 3                            \n" +
                "20 WHILE A > 0                      \n" +
                "30 PRINT A                          \n" +
                "40 A=A-1                            \n" +
                "50 WEND                             ";

            //

            string result =
                "3" + "\n" +
                "2" + "\n" +
                "1" + "\n";

            TestHelper.TestProgram(sourceCode, result);
        }
    }
}
