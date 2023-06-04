// See https://aka.ms/new-console-template for more information
using System.Diagnostics;


string currentDirectory = Directory.GetCurrentDirectory();
string gitFolder = $"{currentDirectory}\\.git";
bool gitFolderExist = Directory.Exists(gitFolder);

void git (string cmmd)
    {
        new Process
        {
            StartInfo =
                {
                    FileName = "cmd",
                    //WorkingDirectory = currentDirectory,
                    Arguments = $"/C cd {currentDirectory} && git {cmmd}"
                }
        }.Start();

        Task.Delay(1000).Wait();
    }

Console.WriteLine($"Curent dir \t : {currentDirectory}");
//Console.WriteLine($"Curent git dir \t : {gitFolder}");
Console.WriteLine($"Git inited \t : {Directory.Exists(gitFolderExist.ToString())}");

if (!gitFolderExist)
{
    Console.WriteLine("GIT INIT");
    git("init");
}


git("add .");

Console.WriteLine("Your commit message : ");
string msgCommit = Console.ReadLine();

git($"commit -m \"{msgCommit}\"");

git("log --oneline --graph");

    