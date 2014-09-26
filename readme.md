# edge-lsharp

Run lisp [(LSharp)](https://github.com/RobBlackwell/LSharp) in node.js with [edge.js](https://github.com/tjanczuk/edge).

## Example

Write a factorial function in lisp, and call it from JavaScript:

```js
var edge = require('edge');
var fact = edge.func('lsharp', function(){/*

(def fact(n) 
	(if (is n 0) 1 (* n (fact (- n 1)))))

*/});

fact([5], function(err, answer){
	console.log(answer);
	// = 120
});
```

## Installation

```
$ npm install edge
$ npm install edge-lsharp
```

## Usage

Pass the lisp code in as either a comment (as above), a string, or a filename (as below):

```js
var edge = require('edge');
var lisp = edge.func('lsharp', 'lisp-func.ls');

lisp(['arg1', 'arg2'], function(err, result){
	
});
```

Evaluate a function in lisp, and write to the console:

```js
var edge = require('edge');
var ls = edge.func('lsharp', '(prn "Hello, World")');

ls([], function(err, greeting){
	// Hello, World
});
```

## License

MIT
