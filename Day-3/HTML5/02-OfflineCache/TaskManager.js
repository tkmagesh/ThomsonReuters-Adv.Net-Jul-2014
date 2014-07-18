
	(function(){
		window.addEventListener("DOMContentLoaded",init);
		var taskStorage = new TaskStorage();

		function init(){
			document.getElementById("btnAddTask").addEventListener("click",onBtnAddTaskClick);
			document.getElementById("btnRemoveCompleted").addEventListener("click",onBtnRemoveCompletedClick);
			loadInitialTasks();
		}
		function loadInitialTasks(){
			var initialTasks = taskStorage.getAll();
			initialTasks.forEach(addTaskToUI);
		}
		function onBtnAddTaskClick(){
			var taskName = document.getElementById("txtTask").value;
			var newTask = taskStorage.add(taskName);
			addTaskToUI(newTask);
			
		}
		function addTaskToUI(task){
			var newTask = document.createElement("li");
			newTask.innerHTML = task.name;
			newTask.setAttribute("taskId", task.id);
			newTask.addEventListener("click", onTaskItemClick);
			document.getElementById("ulTaskList").appendChild(newTask);
		}
		function onTaskItemClick(){
			this.classList.toggle("completed");
		}
		function onBtnRemoveCompletedClick(){
			var taskItems = document.getElementById("ulTaskList").children;
			for(var i=taskItems.length-1;i>=0;i--)
				if (taskItems[i].classList.contains("completed")){
					taskStorage.remove(taskItems[i].getAttribute("taskId"));
					taskItems[i].remove();
				}
		}
	})()