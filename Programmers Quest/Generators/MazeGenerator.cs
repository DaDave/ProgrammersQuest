using System;
using System.Collections.Generic;
using Programmers_Quest.Models;
using Programmers_Quest.Models.Creatures;

namespace Programmers_Quest.Generators
{
    public class MazeGenerator
    {
        private readonly Random _random = new(Environment.TickCount);
        private readonly ItemGenerator _itemGenerator = new();
        private readonly CreatureGenerator _creatureGenerator = new();
        private List<string> _randomAreaNames =  new()
        {
                "Startup.cs",
                "package.config",
                "AssemblyInfo.cs",
                "User.cs",
                "IUser.cs",
                "MainWindow.xaml.cs",
                "DependencyInjection.cs",
                "LoadingPage.xaml.cs",
                "App.config",
                "App.xaml.cs",
                "FileReader.cs",
                "FileWriter.cs",
                "DataTable.cs",
                "about.html",
                "Resources.resx",
                "README.md",
                "launch.json",
                "MainForm.cs",
                "SettingsForm.cs",
                "AboutForm.cs",
                "DashboardForm.cs",
                "Program.cs",
                "Web.config",
                "appsettings.json",
                "launchSettings.json",
                "Filter.cs",
                "BaseModel.cs",
                "RequestContext.cs",
                "PaginationValues.cs",
                "SortingValues.cs",
                "Decrypt.cs",
                "Encrypt.cs",
                "CreateController.cs",
                "UpdateController.cs",
                "DeleteController.cs",
                "ReadController.cs",
                "CreateService.cs",
                "UpdateService.cs",
                "DeleteService.cs",
                "ReadService.cs",
                "CreateRepository.cs",
                "UpdateRepository.cs",
                "DeleteRepository.cs",
                "ReadRepository.cs",
                "IFilter.cs",
                "IBaseModel.cs",
                "IRequestContext.cs",
                "IPaginationValues.cs",
                "ISortingValues.cs",
                "IDecrypt.cs",
                "IEncrypt.cs",
                "ICreateController.cs",
                "IUpdateController.cs",
                "IDeleteController.cs",
                "IReadController.cs",
                "ICreateService.cs",
                "IUpdateService.cs",
                "IDeleteService.cs",
                "IReadService.cs",
                "ICreateRepository.cs",
                "IUpdateRepository.cs",
                "IDeleteRepository.cs",
                "IReadRepository.cs",
                "BaseModel.cs",
                "BaseValidator.cs",
                "IBaseModel.cs",
                "IBaseValidator.cs",
                "CustomException.cs",
                "ICustomException.cs",
                "ExceptionInterceptor.cs",
                "Context.cs"
            };
        public Maze Generate(int areaAmount)
        {
            var maze = new Maze {Areas = new List<Area>()};
            GenerateNewArea(maze, 0);
            GenerateNewMoveForArea(maze, 0, 1);
            if (_random.Next(0, 2) == 1)
            {
                var item = GenerateNewItem();
                if (item != null)
                {
                    maze.Areas[0].Items.Add(item);
                }
            }
            maze.Areas[0].Creatures.Add(GenerateNewCreature(CreatureType.Mate));
            for (var i = 1; i < areaAmount; i++)
            {
                GenerateNewArea(maze, i);
                GenerateNewMoveForArea(maze, i, i-1);
                if (_random.Next(0, 2) == 1)
                {
                    var item = GenerateNewItem();
                    if (item != null)
                    {
                        maze.Areas[i].Items.Add(item);
                    }
                }
                if (i < areaAmount-1 && _random.Next(0, 5) == 1)
                {
                    maze.Areas[i].Creatures.Add(GenerateNewCreature(CreatureType.Enemy));
                }
                if (i == areaAmount-1)
                {
                    maze.Areas[i].Creatures.Add(GenerateNewCreature(CreatureType.Boss));
                }
                if (i != areaAmount-1)
                {
                    GenerateNewMoveForArea(maze, i, i+1);
                    var randomAreaId = _random.Next(0, i - 1);
                    if(!maze.Areas[i].Moves.Exists(x => x.Id == randomAreaId))
                    {
                        GenerateNewMoveForArea(maze, i, randomAreaId);
                        GenerateNewMoveForArea(maze, randomAreaId, i);
                    }
                }
            }
            return maze;
        }

        private void GenerateNewMoveForArea(Maze maze, int areaId, int moveId)
        {
            maze.Areas[areaId].Moves.Add(new Move
            {
                Id = moveId,
                Name = RandomizeMoveName()
            });
        }

        private void GenerateNewArea(Maze maze, int id)
        {
            maze.Areas.Add(new Area
            {
                Id = id,
                Name = RandomizeAreaName()
            });
        }
        
        private Item GenerateNewItem()
        {
            return _itemGenerator.Generate();
        }
        
        private Creature GenerateNewCreature(CreatureType creatureType)
        {
            return _creatureGenerator.Generate(creatureType);
        }

        private string RandomizeAreaName()
        {
            var randomIndex = _random.Next(_randomAreaNames.Count);
            var randomAreaName = _randomAreaNames[randomIndex];
            _randomAreaNames.RemoveAt(randomIndex);
            return randomAreaName;
        }
        private string RandomizeMoveName()
        {
            var moveNames = new List<string>
            {
                "Use 'Go to function definition'",
                "Use 'Go to usages'",
                "Click random file in project",
                "Click next file in project",
                "Use debugger and press 'Step over'",
                "Use debugger and press 'Step into'",
                "Use debugger and press 'Step out'",
                "Use 'Find in Files' to search for a specific part of code",
                "Search for similar variables in other files",
                "Search for similar function in other files"
            };
            var randomIndex = _random.Next(moveNames.Count);
            return moveNames[randomIndex];
        }
    }
}