using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine;
using KModkit;
using System.IO;

public class TableMadness : MonoBehaviour
{
    public KMAudio bombaudio;
    public KMBombInfo bomb;
    public KMBombModule module;
    public KMSelectable[] buttons;
    public TextMesh screentext;
    public TextMesh[] answertexts;



    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;
    private bool moduleReady = false;

    List<List<int[,]>> TableCollection = new List<List<int[,]>>();

    int[,] Table11 = new int[5, 5]{
        {54,13,35,11,45},
        {34,15,41,53,51},
        {14,42,52,44,22},
        {12,24,25,33,21},
        {23,55,32,31,43}
        };

    int[,] Table12 = new int[5, 5]{
        {51,24,53,45,54},
        {43,23,52,32,14},
        {11,42,13,34,25},
        {22,21,41,12,35},
        {31,44,33,15,55}
        };

    int[,] Table13 = new int[5, 5]{
        {34,15,35,52,32},
        {42,14,54,41,55},
        {21,45,43,25,11},
        {23,22,33,13,24},
        {53,31,51,44,12}
        };

    int[,] Table14 = new int[5, 5]{
        {12,54,55,34,23},
        {43,45,11,42,35},
        {52,15,24,51,32},
        {13,14,41,44,31},
        {53,33,25,22,21}
        };

    int[,] Table15 = new int[5, 5]{
        {23,21,43,22,52},
        {33,53,12,41,32},
        {11,51,35,45,44},
        {24,54,55,25,31},
        {34,14,42,13,15}
        };

    int[,] Table21 = new int[5, 5]{
        {32,44,35,11,31},
        {54,45,41,24,33},
        {14,12,43,34,13},
        {51,15,53,21,22},
        {42,25,23,52,55}
        };

    int[,] Table22 = new int[5, 5]{
        {22,13,43,14,33},
        {31,54,25,45,11},
        {52,32,41,55,23},
        {35,51,34,15,21},
        {44,12,42,53,24}
        };

    int[,] Table23 = new int[5, 5]{
        {24,25,45,52,35},
        {54,31,13,42,43},
        {51,53,41,55,33},
        {11,44,23,14,34},
        {22,32,12,21,15}
        };

    int[,] Table24 = new int[5, 5]{
        {55,15,45,32,34},
        {54,25,11,12,33},
        {44,41,43,22,52},
        {31,53,42,14,51},
        {21,23,24,13,35}
        };

    int[,] Table25 = new int[5, 5]{
        {11,13,32,31,43},
        {22,51,44,12,34},
        {35,53,41,23,54},
        {42,21,15,33,55},
        {45,25,24,52,14}
        };

    int[,] Table31 = new int[5, 5]{
        {45,15,33,55,11},
        {52,54,23,51,44},
        {35,25,12,13,32},
        {42,14,43,53,41},
        {22,21,24,31,34}
        };

    int[,] Table32 = new int[5, 5]{
        {51,13,32,21,31},
        {35,22,24,12,55},
        {43,11,53,52,54},
        {15,45,14,33,44},
        {42,25,41,34,23}
        };

    int[,] Table33 = new int[5, 5]{
        {11,42,55,44,43},
        {21,24,51,15,45},
        {41,25,13,34,32},
        {22,52,14,31,35},
        {53,33,12,54,23}
        };

    int[,] Table34 = new int[5, 5]{
        {22,44,51,12,23},
        {52,45,13,53,33},
        {31,55,42,41,43},
        {11,54,25,21,14},
        {35,24,34,32,15}
        };

    int[,] Table35 = new int[5, 5]{
        {11,55,45,23,44},
        {35,14,13,15,34},
        {42,12,21,41,25},
        {51,53,31,32,33},
        {22,24,43,52,54}
        };

    int[,] Table41 = new int[5, 5]{
        {42,45,14,21,53},
        {55,51,12,54,32},
        {13,35,11,34,31},
        {43,15,52,25,24},
        {22,44,23,41,33}
        };

    int[,] Table42 = new int[5, 5]{
        {21,11,34,23,32},
        {12,51,24,42,44},
        {33,14,55,52,41},
        {31,13,25,54,53},
        {45,43,22,35,15}
        };

    int[,] Table43 = new int[5, 5]{
        {54,35,23,21,13},
        {32,34,44,52,41},
        {42,25,55,45,12},
        {31,14,24,15,53},
        {22,11,51,33,43}
        };

    int[,] Table44 = new int[5, 5]{
        {22,21,42,23,11},
        {43,45,34,41,15},
        {13,53,12,44,35},
        {55,52,33,54,51},
        {25,24,32,31,14}
        };

    int[,] Table45 = new int[5, 5]{
        {14,45,24,44,22},
        {54,21,51,34,15},
        {11,53,25,33,43},
        {12,32,23,52,31},
        {42,35,41,55,13}
        };

    int[,] Table51 = new int[5, 5]{
        {44,53,45,23,52},
        {34,43,14,11,32},
        {33,13,42,24,51},
        {41,54,12,25,22},
        {35,15,31,21,55}
        };

    int[,] Table52 = new int[5, 5]{
        {12,52,13,33,14},
        {43,23,51,22,54},
        {53,25,41,15,44},
        {24,35,45,21,32},
        {31,34,55,42,11}
        };

    int[,] Table53 = new int[5, 5]{
        {42,41,13,34,53},
        {33,21,51,24,44},
        {43,35,31,22,15},
        {12,45,54,25,23},
        {11,55,32,14,52}
        };

    int[,] Table54 = new int[5, 5]{
        {12,25,11,31,22},
        {51,44,14,33,24},
        {35,45,23,13,54},
        {55,53,41,42,32},
        {34,43,52,21,15}
        };

    int[,] Table55 = new int[5, 5]{
        {21,45,32,22,42},
        {43,24,33,12,31},
        {25,55,14,34,13},
        {15,23,53,51,11},
        {52,54,35,44,41}
        };

    private int row = 0;
    private int col = 0;
    private int initialcell = 0;
    private int solution = 0; 

    private void Awake()
    {
        moduleId = moduleIdCounter++;
        foreach (KMSelectable button in buttons)
        {
            KMSelectable pressedButton = button;
            button.OnInteract += delegate () { ButtonPress(pressedButton); return false; };
        }
    }


    // Use this for initialization
    void Start()
    {
        TableCollection = new List<List<int[,]>>()
        {
            new List<int[,]>{Table11,Table12,Table13,Table14,Table15 },
            new List<int[,]>{Table21,Table22,Table23,Table24,Table25 },
            new List<int[,]>{Table31,Table32,Table33,Table34,Table35 },
            new List<int[,]>{Table41,Table42,Table43,Table44,Table45 },
            new List<int[,]>{Table51,Table52,Table53,Table54,Table55 }
        };

        //Generate Starting Screen
        GetStartingScreen();
        //Find Solution
        solution = GetSolution();
        Log("The final solution is " + ConvertToCoordinate(solution));

        moduleReady = true;

    }

    void GetStartingScreen()
    {
        row = UnityEngine.Random.Range(0, 4);
        col = UnityEngine.Random.Range(0, 4);
        initialcell = (row + 1) * 10 + (col + 1);
        char c1 = (char)('A' + row);
        string c2 = (col + 1).ToString();
        var s = c1.ToString() + c2;
        screentext.text = s;
        Log("The starting coordinate is " + s);
    }

    int GetSolution()
    {
        var sum = 0;
        bomb.GetSerialNumberNumbers().ToList().ForEach(delegate (int i) { sum += i; });
        sum = (sum % 3) + 3;
        Log(sum + " iterations required to solve.");
        var firsttablerow = bomb.GetSerialNumberLetters().First() - 'A' + 1;
        var firsttablecol = bomb.GetSerialNumberNumbers().First();
        firsttablerow %= 5;
        firsttablecol %= 5;
        if (firsttablerow == 0) firsttablerow += 5;
        if (firsttablecol == 0) firsttablecol += 5;
        var initialtable = firsttablerow * 10 + firsttablecol;
        var firsttable = GetTable(initialtable);
        TableLoop(initialcell, initialtable, -1);
        for(int i = 0; i < sum - 1; i++)
        {
            TableLoop(cellref, tableref, i);
        }

        return tableref;
    }

    private int cellref = 0;
    private int tableref = 0; 

    void TableLoop(int cellAref, int tableAref, int iteration)
    {
        //cell A = (A)
        //table A = [A]
        //(A) in [A]
        //[(A)] = [B]
        //[B](A) = (B)
        //[B](B) = (C)
        //[C] = ([A])
        //back to start
        Log("Iteration " + (iteration + 2));
        var tableA = GetTable(tableAref);
        var cellA = GetCell(cellAref, tableA);
        Log("Step 1: Starting cell " + ConvertToCoordinate(cellAref) + " has value " + ConvertToCoordinate(cellA) + " in starting table " + ConvertToCoordinate(GetTableNameAsCell(tableA)));
        var tableB = GetTable(cellA);
        Log("Step 2: New table is " + ConvertToCoordinate(GetTableNameAsCell(tableB)));
        var cellB1 = GetCell(cellAref, tableB);
        var cellB2 = GetCell(cellB1, tableB);
        Log("Step 3: Cell " + ConvertToCoordinate(cellAref) + " has value " + ConvertToCoordinate(cellB1) + " and cell " + ConvertToCoordinate(cellB1) + " has value " + ConvertToCoordinate(cellB2));
        var tableC = GetTable(cellB2);
        Log("Step 4: Heading to new table " + ConvertToCoordinate(GetTableNameAsCell(tableC)));
        var celltemp = GetTableNameAsCell(tableA);
        var cellC = GetCell(celltemp, tableC);
        Log("Step 5: Final cell " + ConvertToCoordinate(GetTableNameAsCell(tableA)) + " has value " + ConvertToCoordinate(cellC) + " in table " + ConvertToCoordinate(GetTableNameAsCell(tableC)));
        cellref = GetTableNameAsCell(tableC);
        tableref = cellC;
    }

    string ConvertToCoordinate(int cell)
    {
        string s = "";
        s += letters[cell / 10 - 1];
        s += numbers[cell % 10 - 1];
        return s;
    }

    int GetTableNameAsCell(int[,] table)
    {
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                if (table.Cast<int>().SequenceEqual(TableCollection[i][j].Cast<int>()))
                {
                    return (i + 1) * 10 + (j + 1);
                }
            }
        }
        return -1; 
    }

    int[,] GetTable(int cell)
    {
        var row = GetRow(cell);
        var col = GetCol(cell);
        return TableCollection[row][col];
    }

    int GetCell(int cell, int[,] table)
    {
        var r = GetRow(cell);
        var c = GetCol(cell);
        return table[r,c];
    }

    int GetRow(int cell)
    {
        return cell / 10 - 1;
    }

    int GetCol(int cell)
    {
        return cell % 10 - 1;
    }

    char[] letters = { 'A', 'B', 'C', 'D', 'E' };
    char[] numbers = { '1', '2', '3', '4', '5' };

    void ButtonPress(KMSelectable button)
    {
        if (moduleReady)
        {
            var lettertext = answertexts[0].text;
            var numbertext = answertexts[1].text;
            var letterindex = lettertext[0] - 'A';
            var numberindex = numbertext[0] - '1';
            button.AddInteractionPunch();
            bombaudio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, this.transform);
            switch (button.name)
            {
                case "ArrowDownLetter":
                    letterindex = mod(letterindex - 1, 5);
                    break;
                case "ArrowUpLetter":
                    letterindex = mod(letterindex + 1, 5);
                    break;
                case "ArrowDownNumber":
                    numberindex = mod(numberindex - 1, 5);
                    break;
                case "ArrowUpNumber":
                    numberindex = mod(numberindex + 1, 5);
                    break;
                case "Screen":
                    Log("User submitted " + ConvertToCoordinate((letterindex + 1) * 10 + numberindex + 1));
                    if (((letterindex + 1) * 10 + numberindex + 1) == solution)
                    {
                        Log("Correct! Module Solved!");
                        module.HandlePass();
                        bombaudio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.CorrectChime, this.transform);
                        moduleReady = false;
                        
                    }
                    else
                    {
                        Log("Incorrect! The expected answer was " + ConvertToCoordinate(solution));
                        module.HandleStrike();
                    }
                    break;                        
            }

        
            answertexts[0].text = letters[letterindex].ToString();
            answertexts[1].text = numbers[numberindex].ToString();
        }
    }


    void MakeNewTables()
    {
        var path = "";
        List<List<int>> l = new List<List<int>>();
        List<int> numberlist = new List<int>();
        StreamWriter swrite = new StreamWriter(path,true);
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                numberlist.Add((i+1) * 10 + (j+1));
            }
        }
        for(int i = 0; i < 25; i++)
        {
        makelist:
            List<int> nums = new List<int>();
            nums.AddRange(numberlist.Shuffle());
            if (i > 0)
            {
                if (!ListContainsList(l, nums))
                {
                    l.Add(nums);
                    var tableindex = (((i - i % 5) / 5) + 1) * 10 + (i % 5 + 1);
                    swrite.WriteLine("int[,] Table" + tableindex + " = new int[5,5]{ ");
                    for (int r = 0; r < 5; r++)
                    {
                        string s = "{";
                        for (int c = 0; c < 5; c++)
                        {
                            s += nums[r*5 + c].ToString();
                            if (c < 4) s += ",";
                        }
                        if (r < 4) s += "},";
                        else s += "}";
                        swrite.WriteLine(s);
                    }
                    swrite.WriteLine("};");

                    swrite.WriteLine(" ");
                }
                else
                {
                    goto makelist;
                }
            }
            else
            {
                l.Add(nums);
                swrite.WriteLine("int[,] Table11 = new int[5,5]{ ");
                for (int r = 0; r < 5; r++)
                {
                    string s = "{";
                    for (int c = 0; c < 5; c++)
                    {
                        s += nums[r*5 + c].ToString();
                        if (c < 4) s += ",";
                    }
                    if (r < 4) s += "},";
                    else s += "}";
                    swrite.WriteLine(s);
                }
                swrite.WriteLine("};");
                swrite.WriteLine(" ");
            }
        }
        swrite.Close();
    }

    void MakeTablesHTML()
    {
        var path = "";
        StreamWriter swrite = new StreamWriter(path, true);
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                swrite.WriteLine("<table style=\"display: inline-table; justify-content: space-around; \">");
                swrite.WriteLine("\t<caption><h4>Table " + ConvertToCoordinate(GetTableNameAsCell(TableCollection[i][j])) + "</h4></caption>");
                for (int row = 0; row < 5; row++)
                {
                    swrite.WriteLine("\t<tr>");
                    for (int col = 0; col < 5; col++)
                    {
                        swrite.WriteLine("\t\t<th>" + ConvertToCoordinate(TableCollection[i][j][row, col]) + "</th>");
                    }
                    swrite.WriteLine("\t</tr>");
                }
                swrite.WriteLine("</table>");
                swrite.WriteLine("");
            }
        }
        swrite.Close();
    }

    public static bool ListContainsList(List<List<int>> lists, List<int> l)
    {
        foreach (List<int> list in lists)
        {
            if (list.SequenceEqual(l)) return true;
        }
        return false;
    }

    string ListToString(List<string> l)
    {
        string str = "";
        foreach (var s in l) str += s;
        return str;
    }

    string ListToString(List<int> l)
    {
        string str = "";
        foreach (var s in l) str += s.ToString();
        return str;
    }

    string ListToString(List<char> l)
    {
        string str = "";
        foreach (var s in l) str += s.ToString();
        return str;
    }

    private int mod(int x, int m)
    {
        return (x % m + m) % m;
    }

    private void Log(string s)
    {
        Debug.LogFormat("[Table Madness #{0}] " + s, moduleId);
    }

#pragma warning disable 414
    private readonly string TwitchHelpMessage = @"!{0} Letter Number submit (examples: !1 submit A4, !1 submit B 3 , !1 submit e1)";
#pragma warning restore 414
    IEnumerator ProcessTwitchCommand(string command)
    {
        string[] parameters = command.Split(' ', ',');
        List<string> newparams = new List<string>(parameters.ToList());
        if (newparams.Count < 4 && Regex.IsMatch(newparams[0], @"^\s*submit\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {           
            if(newparams[1].Length > 1)
            {
                newparams.Add(newparams[1][1].ToString());
                newparams[1] = newparams[1][0].ToString();
            }
            var let = 'F';
            var num = '6';
            char.TryParse(newparams[1].ToUpper(), out let);
            char.TryParse(newparams[2], out num);
            if (letters.Contains(let))
            {
                while (!answertexts[0].text.Equals(let.ToString()))
                {
                    yield return new WaitForSeconds(0.05f);
                    buttons[1].OnInteract();
                }
            }
            if (numbers.Contains(num))
            {
                while (!answertexts[1].text.Equals(num.ToString()))
                {
                    yield return new WaitForSeconds(0.05f);
                    buttons[3].OnInteract();
                }
            }
            buttons[4].OnInteract();
            yield break;
        }
    }

}       