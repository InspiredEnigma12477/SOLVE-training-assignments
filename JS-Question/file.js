console.log('file.js');
for (var i = 0; i < 10; i++) {
	var button = document.getElementById('button' + i);
	button.onclick = createOnClickHandler(i);
}

function createOnClickHandler(num) {
	return function () {
		alert(num);
	};
}