﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Web.ViewModels.Board
{
    public class BoardSelectViewModel
    {

        public BoardSelectViewModel()
        {
            Tasks = new List<TaskViewModel>();
        }
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public IEnumerable<TaskViewModel> Tasks { get; set; } = null!; 
    }
}
