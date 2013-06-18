var canvas;
var context;
var images;

function main(){
	initializeCanvas();
	loadImages();
	//move into next state
}

function initializeCanvas(){
	canvas = document.createElement("canvas");
	context = canvas.getContext("2d");
	canvas.width = 800;
	canvas.height = 480;
	document.body.appendChild(canvas);
}

function loadImages(){
	var loadedimages = 0;
	var imagePointers = [];
	
	imagePointers = ["Resources/Art/Image0.bmp",
						"Resources/Art/Image1.bmp"];
}