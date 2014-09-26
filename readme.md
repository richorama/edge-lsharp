# edge-lsharp

Run lisp in node.

## Example

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