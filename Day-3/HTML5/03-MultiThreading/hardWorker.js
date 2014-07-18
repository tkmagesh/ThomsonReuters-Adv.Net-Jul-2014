function doWork(){
	for(var i=0;i<10000;i++){
		if (i % 100 == 0){
			self.postMessage({
				type : "progress",
				percentCompleted : i / 100
			});
		}
		for(var j=0;j<10000;j++)
			for(var k=0;k<100;k++){}
	}
}
//doWork();
self.addEventListener("message",function(msgArg){
	if (msgArg.data === "start"){
		doWork();
		self.postMessage({type : "done"});
	}
});