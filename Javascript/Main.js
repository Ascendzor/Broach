var canvas;
var context;

function main(){
	initializeCanvas();
	//load all art
	//move into next state
}

function initializeCanvas(){
	canvas = document.createElement("canvas");
	context = canvas.getContext("2d");
	canvas.width = 800;
	canvas.height = 480;
	document.body.appendChild(canvas);
}