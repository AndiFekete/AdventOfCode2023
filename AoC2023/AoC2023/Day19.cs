using System.Security.Cryptography.X509Certificates;

namespace AoC2023
{
    public static class Day19
    {
        private static List<Workflow> _workflows = new List<Workflow>();
        private static List<Part> _parts = new List<Part>();
        public static void PartOne()
        {
            var lines = File.ReadAllLines(Utils.InputFileName).ToList();
            int i = 0;
            for (i = 0; i < lines.Count; i++)
            {
                if (lines[i] == "") break;

                var name = lines[i].Split("{")[0];
                var rules = new List<Rule>();
                foreach (var ruleText in lines[i].Split("{")[1].TrimEnd('}').Split(","))
                {
                    var rule = new Rule();
                    if (!ruleText.Contains(':'))
                    {
                        rule.Destination = ruleText;
                    }
                    else
                    {
                        var split = ruleText.Split(':');
                        rule.Destination = split[1];
                        if (split[0].Contains('>'))
                        {
                            rule.Comparison = ">";
                            rule.Category = split[0].Split('>')[0];
                            rule.Target = int.Parse(split[0].Split('>')[1]);
                        }
                        else
                        {
                            rule.Comparison = "<";
                            rule.Category = split[0].Split('<')[0];
                            rule.Target = int.Parse(split[0].Split('<')[1]);
                        }
                    }

                    
                    rules.Add(rule);
                }
                _workflows.Add(new Workflow()
                {
                    Name = name, 
                    Rules = rules
                });
            }

            for (int j = i+1; j < lines.Count; j++)
            {
                var split = lines[j].Trim('{').TrimEnd('}').Split(',');
                _parts.Add(new Part()
                {
                    X = int.Parse(split[0].Split('=')[1]),
                    M = int.Parse(split[1].Split('=')[1]),
                    A = int.Parse(split[2].Split('=')[1]),
                    S = int.Parse(split[3].Split('=')[1]),
                });
            }

            foreach (var part in _parts)
            {
                Console.WriteLine(part.X);
                var workflow = _workflows.FirstOrDefault(w => w.Name == "in");
                while (part is { Accepted: false, Rejected: false })
                {
                    foreach (var rule in workflow.Rules)
                    {
                        bool workflowChanged = false;
                        switch (rule.Category)
                        {
                            case "x":
                                if (rule.Comparison == ">")
                                {
                                    if (part.X > rule.Target)
                                    {
                                        if (rule.Destination == "A")
                                        {
                                            part.Accepted = true;
                                            Console.WriteLine("Accepted");
                                        }
                                        else if (rule.Destination == "R")
                                        {
                                            part.Rejected = true;
                                            Console.WriteLine("Rejected");
                                        }
                                        else
                                        {
                                            workflow = _workflows.First(w => w.Name == rule.Destination);
                                            workflowChanged = true;
                                            Console.WriteLine(rule.Destination);
                                        }
                                    }
                                }
                                else if (part.X < rule.Target)
                                {
                                    if (rule.Destination == "A")
                                    {
                                        part.Accepted = true;
                                        Console.WriteLine("Accepted");
                                    }
                                    else if (rule.Destination == "R")
                                    {
                                        part.Rejected = true;
                                        Console.WriteLine("Rejected");
                                    }
                                    else
                                    {
                                        workflow = _workflows.First(w => w.Name == rule.Destination);
                                        workflowChanged = true;
                                        Console.WriteLine(rule.Destination);
                                    }
                                }
                                break;
                            case "m":
                                if (rule.Comparison == ">")
                                {
                                    if (part.M > rule.Target)
                                    {
                                        if (rule.Destination == "A")
                                        {
                                            part.Accepted = true;
                                            Console.WriteLine("Accepted");
                                        }
                                        else if (rule.Destination == "R")
                                        {
                                            part.Rejected = true;
                                            Console.WriteLine("Rejected");
                                        }
                                        else
                                        {
                                            workflow = _workflows.First(w => w.Name == rule.Destination);
                                            workflowChanged = true;
                                            Console.WriteLine(rule.Destination);
                                        }
                                    }
                                }
                                else if (part.M < rule.Target)
                                {
                                    if (rule.Destination == "A")
                                    {
                                        part.Accepted = true;
                                        Console.WriteLine("Accepted");
                                    }
                                    else if (rule.Destination == "R")
                                    {
                                        part.Rejected = true;
                                        Console.WriteLine("Rejected");
                                    }
                                    else
                                    {
                                        workflow = _workflows.First(w => w.Name == rule.Destination);
                                        workflowChanged = true;
                                        Console.WriteLine(rule.Destination);
                                    }
                                }
                                break;
                            case "a":
                                if (rule.Comparison == ">")
                                {
                                    if (part.A > rule.Target)
                                    {
                                        if (rule.Destination == "A")
                                        {
                                            part.Accepted = true;
                                            Console.WriteLine("Accepted");
                                        }
                                        else if (rule.Destination == "R")
                                        {
                                            part.Rejected = true;
                                            Console.WriteLine("Rejected");
                                        }
                                        else
                                        {
                                            workflow = _workflows.First(w => w.Name == rule.Destination);
                                            workflowChanged = true;
                                            Console.WriteLine(rule.Destination);
                                        }
                                    }
                                }
                                else if (part.A< rule.Target)
                                {
                                    if (rule.Destination == "A")
                                    {
                                        part.Accepted = true;
                                        Console.WriteLine("Accepted");
                                    }
                                    else if (rule.Destination == "R")
                                    {
                                        part.Rejected = true;
                                        Console.WriteLine("Rejected");
                                    }
                                    else
                                    {
                                        workflow = _workflows.First(w => w.Name == rule.Destination);
                                        workflowChanged = true;
                                        Console.WriteLine(rule.Destination);
                                    }
                                }
                                break;
                            case "s":
                                if (rule.Comparison == ">")
                                {
                                    if (part.S > rule.Target)
                                    {
                                        if (rule.Destination == "A")
                                        {
                                            part.Accepted = true;
                                            Console.WriteLine("Accepted");
                                        }
                                        else if (rule.Destination == "R")
                                        {
                                            part.Rejected = true;
                                            Console.WriteLine("Rejected");
                                        }
                                        else
                                        {
                                            workflow = _workflows.First(w => w.Name == rule.Destination);
                                            workflowChanged = true;
                                            Console.WriteLine(rule.Destination);
                                        }
                                    }
                                }
                                else if (part.S < rule.Target)
                                {
                                    if (rule.Destination == "A")
                                    {
                                        part.Accepted = true;
                                        Console.WriteLine("Accepted");
                                    }
                                    else if (rule.Destination == "R")
                                    {
                                        part.Rejected = true;
                                        Console.WriteLine("Rejected");
                                    }
                                    else
                                    {
                                        workflow = _workflows.First(w => w.Name == rule.Destination);
                                        workflowChanged = true;
                                        Console.WriteLine(rule.Destination);
                                    }
                                }
                                break;
                            default:
                                if (rule.Destination == "A")
                                {
                                    part.Accepted = true;
                                    Console.WriteLine("Accepted");
                                }
                                else if (rule.Destination == "R")
                                {
                                    part.Rejected = true;
                                    Console.WriteLine("Rejected");
                                }
                                else
                                {
                                    workflow = _workflows.First(w => w.Name == rule.Destination);
                                    Console.WriteLine(rule.Destination);
                                }
                                workflowChanged = true;
                                break;
                        }

                        if (workflowChanged || part.Accepted || part.Rejected) 
                            break;
                    }
                }
            }
            Console.WriteLine(_parts.Where(p => p.Accepted).Select(p => p.Rating).Sum());
        }

    }

    public class Workflow
    {
        public string Name { get; set; }    
        public List<Rule> Rules { get; set; }
    }

    public class Rule
    {
        public string Category { get; set; }
        public string Comparison { get; set; }
        public int Target { get; set; }
        public string Destination { get; set; }
    }

    public class Part
    {
        public int X { get; set; }
        public int M { get; set; }
        public int A { get; set; }
        public int S { get; set; }

        public int Rating => X + M + A + S;

        public bool Accepted { get; set; }
        public bool Rejected { get; set; }
    }
}
