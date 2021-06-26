using System.Collections.Generic;
using AutoMapper;
using KarmaAPI.DTOS;
using KarmaAPI.Models;
using MongoDB.Driver;
using System;

namespace KarmaAPI.Services
{
    public class TaskService
    {
        private readonly IMongoCollection<Task> _tasks;

        private readonly IMapper _mapper;
        public TaskService(IDatabaseSettings settings, IMapper mapper) {

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _tasks = database.GetCollection<Task>("Tasks");
            _mapper = mapper;
        }

        public Task createTask(Task task){
            _tasks.InsertOne(task);
            return task;            
        }

        public IList<Task> getAllTasks(){        
         var tasks =  _tasks.Find(tsk => true).ToList();  
         return tasks;
        }      
        public  Task Find(string id) =>
            _tasks.Find(tsk => tsk.TaskId == id).SingleOrDefault();

        public void Update(Task task) => 
            _tasks.ReplaceOne(tsk => tsk.TaskId == task.TaskId, task);

    }
}