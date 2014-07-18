function TaskStorage(){
		var storage = window.localStorage;
		this.add = function(taskName){
			var newId = new Date().getTime().toString();
			storage.setItem(newId,taskName);
			return {
				id : newId,
				name : taskName
			}
		};
		this.getAll = function(){
			var result = [];
			for(var i=0;i<storage.length;i++){
				var taskId = storage.key(i);
				var taskName = storage.getItem(taskId);
				result.push({
					id : taskId,
					name : taskName
				});
			}
			return result;
		};
		this.remove = function(taskId){
			storage.removeItem(taskId);
		}
	}