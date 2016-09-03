"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports.ComputationalExpressions = exports.UnitsOfMeasure = exports.Events = exports.Exceptions = exports.Interfaces = exports.Classes = exports.ControlFlow = exports.FunctionsAndCurrying = exports.Structs = exports.ActivePatterns = exports.PatternMatching = exports.OptionType = exports.Generics = exports.DiscriminatedUnions = exports.Enums = exports.TuplesAndRecords = exports.Collections = exports.TypeAliases = exports.Types = exports.Introduction = undefined;

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _fableCore = require("fable-core");

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var Introduction = exports.Introduction = function ($exports) {
  var myFunction = $exports.myFunction = function myFunction(arg1, arg2) {
    var returnValue = arg1 * arg2;
    return returnValue;
  };

  _fableCore.String.fsFormat("Introduction: %A")(function (x) {
    console.log(x);
  })(myFunction(10, 20));

  var factorial = $exports.factorial = function factorial(n) {
    return n === 0 ? 1 : n * factorial(n - 1);
  };

  _fableCore.String.fsFormat("Introduction.factorial(10): %A")(function (x) {
    console.log(x);
  })(factorial(10));

  var myList = $exports.myList = _fableCore.List.ofArray([1, 2, 3, 4, 5]);

  var reverseList = $exports.reverseList = function reverseList(list) {
    return list.tail != null ? _fableCore.List.append(reverseList(list.tail), _fableCore.List.ofArray([list.head])) : new _fableCore.List();
  };

  _fableCore.String.fsFormat("Introduction.reverseList: %A")(function (x) {
    console.log(x);
  })(reverseList(myList));

  return $exports;
}({});

var Types = exports.Types = function ($exports) {
  var a = $exports.a = 100;
  var b = $exports.b = 100;
  var c = $exports.c = "100";

  var f = $exports.f = _fableCore.Date.now();

  var g = $exports.g = null;
  var h = $exports.h = true;
  return $exports;
}({});

var TypeAliases = exports.TypeAliases = function ($exports) {
  return $exports;
}({});

var Collections = exports.Collections = function ($exports) {
  var intList = $exports.intList = _fableCore.List.ofArray([1, 2, 3, 4, 5]);

  var intList_ = $exports["intList'"] = _fableCore.List.ofArray([1, 2, 3, 4, 5]);

  var intArray = $exports.intArray = new Int32Array([1, 2, 3, 4, 5]);
  var intArray_ = $exports["intArray'"] = new Int32Array([1, 2, 3, 4, 5]);
  intArray[3] = 20;

  var intSeq = $exports.intSeq = _fableCore.Seq.delay(function (unitVar) {
    return _fableCore.Seq.append(_fableCore.Seq.singleton(1), _fableCore.Seq.delay(function (unitVar_1) {
      return _fableCore.Seq.append(_fableCore.Seq.singleton(2), _fableCore.Seq.delay(function (unitVar_2) {
        return _fableCore.Seq.singleton(3);
      }));
    }));
  });

  _fableCore.String.fsFormat("Collections.Seq %A")(function (x) {
    console.log(x);
  })(intSeq);

  return $exports;
}({});

var TuplesAndRecords = exports.TuplesAndRecords = function ($exports) {
  var myTuple = $exports.myTuple = ["Hello", "from", "F#", _fableCore.Date.now()];
  return $exports;
}({});

var Enums = exports.Enums = function ($exports) {
  var ColorEnum = $exports.ColorEnum = function ColorEnum() {
    _classCallCheck(this, ColorEnum);
  };

  _fableCore.Util.setInterfaces(ColorEnum.prototype, [], "Main.Enums.ColorEnum");

  return $exports;
}({});

var DiscriminatedUnions = exports.DiscriminatedUnions = function ($exports) {
  var LoginMethods = $exports.LoginMethods = function () {
    function LoginMethods(caseName, fields) {
      _classCallCheck(this, LoginMethods);

      this.Case = caseName;
      this.Fields = fields;
    }

    _createClass(LoginMethods, [{
      key: "Equals",
      value: function Equals(other) {
        return _fableCore.Util.equalsUnions(this, other);
      }
    }]);

    return LoginMethods;
  }();

  _fableCore.Util.setInterfaces(LoginMethods.prototype, ["FSharpUnion", "System.IEquatable"], "Main.DiscriminatedUnions.LoginMethods");

  var myLogin = $exports.myLogin = new LoginMethods("UserIdAndPin", [274161, 6180]);

  var LoginMethods__ = $exports["LoginMethods''"] = function () {
    function LoginMethods__(caseName, fields) {
      _classCallCheck(this, LoginMethods__);

      this.Case = caseName;
      this.Fields = fields;
    }

    _createClass(LoginMethods__, [{
      key: "Equals",
      value: function Equals(other) {
        return _fableCore.Util.equalsUnions(this, other);
      }
    }, {
      key: "CompareTo",
      value: function CompareTo(other) {
        return _fableCore.Util.compareUnions(this, other);
      }
    }]);

    return LoginMethods__;
  }();

  _fableCore.Util.setInterfaces(LoginMethods__.prototype, ["FSharpUnion", "System.IEquatable", "System.IComparable"], "Main.DiscriminatedUnions.LoginMethods''");

  return $exports;
}({});

var Generics = exports.Generics = function ($exports) {
  return $exports;
}({});

var OptionType = exports.OptionType = function ($exports) {
  var Option = $exports.Option = function () {
    function Option(caseName, fields) {
      _classCallCheck(this, Option);

      this.Case = caseName;
      this.Fields = fields;
    }

    _createClass(Option, [{
      key: "Equals",
      value: function Equals(other) {
        return _fableCore.Util.equalsUnions(this, other);
      }
    }, {
      key: "CompareTo",
      value: function CompareTo(other) {
        return _fableCore.Util.compareUnions(this, other);
      }
    }]);

    return Option;
  }();

  _fableCore.Util.setInterfaces(Option.prototype, ["FSharpUnion", "System.IEquatable", "System.IComparable"], "Main.OptionType.Option");

  return $exports;
}({});

var PatternMatching = exports.PatternMatching = function ($exports) {
  var myValue = $exports.myValue = _fableCore.Date.now();

  if (myValue == null) {
    _fableCore.String.fsFormat("PatternMatching.DateTime: nothing is provided")(function (x) {
      console.log(x);
    });
  } else {
    var x = myValue;

    _fableCore.String.fsFormat("PatternMatching.DateTime: %A")(function (x) {
      console.log(x);
    })(x);
  }

  var fibonacci = $exports.fibonacci = function fibonacci(n) {
    return n === 0 ? 0 : n === 1 ? 1 : n < 0 ? function () {
      throw "n";
    }() : fibonacci(n - 1) + fibonacci(n - 2);
  };

  _fableCore.String.fsFormat("PatternMatching.TenthFibonacci: %A ")(function (x) {
    console.log(x);
  })(fibonacci(10));

  var isNull = $exports.isNull = function isNull(x) {
    return x == null ? true : false;
  };

  var myObj = $exports.myObj = "Hello";
  return $exports;
}({});

var ActivePatterns = exports.ActivePatterns = function ($exports) {
  var $IsOdd$IsEven$ = $exports.$IsOdd$IsEven$ = function $IsOdd$IsEven$(n) {
    return n % 2 === 0 ? new _fableCore.Choice("Choice2Of2", [null]) : new _fableCore.Choice("Choice1Of2", [null]);
  };

  {
    var matchValue = 12;
    var activePatternResult121 = $IsOdd$IsEven$(matchValue);

    if (activePatternResult121.Case === "Choice1Of2") {
      _fableCore.String.fsFormat("ActivePatterns: 12 is odd")(function (x) {
        console.log(x);
      });
    } else {
      _fableCore.String.fsFormat("ActivePatterns: 12 is even")(function (x) {
        console.log(x);
      });
    }
  }
  return $exports;
}({});

var Structs = exports.Structs = function ($exports) {
  var Point2D = $exports.Point2D = function () {
    function Point2D() {
      _classCallCheck(this, Point2D);
    }

    _createClass(Point2D, null, [{
      key: ".ctor",
      value: function ctor(x, y) {
        return new Point2D(x, y);
      }
    }]);

    return Point2D;
  }();

  _fableCore.Util.setInterfaces(Point2D.prototype, ["System.IEquatable", "System.IComparable"], "Main.Structs.Point2D");

  var myPoint2D = $exports.myPoint2D = Point2D[".ctor"](2, 3);

  _fableCore.String.fsFormat("Structs.myPoint2D: {%A %A}")(function (x) {
    console.log(x);
  })(myPoint2D.X)(myPoint2D.Y);

  return $exports;
}({});

var FunctionsAndCurrying = exports.FunctionsAndCurrying = function ($exports) {
  var myfunction = $exports.myfunction = function myfunction(arg1, arg2) {
    return arg1 + arg2;
  };

  var result = $exports.result = myfunction(10, 20);

  var add = $exports.add = function add(x, y) {
    return x + y;
  };

  var bicrement = $exports.bicrement = function () {
    var x = 2;
    return function (y) {
      return add(x, y);
    };
  }();

  var r = $exports.r = bicrement(10);
  return $exports;
}({});

var ControlFlow = exports.ControlFlow = function ($exports) {
  var result = $exports.result = 2 > 3 ? "True" : "False";
  var i = (Object.defineProperty($exports, 'i', {
    get: function get() {
      return i;
    },
    set: function set(x) {
      return i = x;
    }
  }), 0);

  while (i < 5) {
    _fableCore.String.fsFormat("ControlFlow.while:%A ")(function (x) {
      console.log(x);
    })(i);

    i = i + 1;
  }

  for (var i_1 = 1; i_1 <= 5; i_1++) {
    _fableCore.String.fsFormat("ControlFlow.for1:%A ")(function (x) {
      console.log(x);
    })(i_1);
  }

  {
    var inputSequence = _fableCore.Seq.toList(_fableCore.Seq.rangeStep(1, 3, 20));

    var _iteratorNormalCompletion = true;
    var _didIteratorError = false;
    var _iteratorError = undefined;

    try {
      for (var _iterator = inputSequence[Symbol.iterator](), _step; !(_iteratorNormalCompletion = (_step = _iterator.next()).done); _iteratorNormalCompletion = true) {
        var i_1 = _step.value;

        _fableCore.String.fsFormat("ControlFlow.for2:%A ")(function (x) {
          console.log(x);
        })(i_1);
      }
    } catch (err) {
      _didIteratorError = true;
      _iteratorError = err;
    } finally {
      try {
        if (!_iteratorNormalCompletion && _iterator.return) {
          _iterator.return();
        }
      } finally {
        if (_didIteratorError) {
          throw _iteratorError;
        }
      }
    }
  }
  return $exports;
}({});

var Classes = exports.Classes = function ($exports) {
  var MyClass = $exports.MyClass = function () {
    function MyClass(x, y) {
      _classCallCheck(this, MyClass);

      this.mx = x;
      this.my = y;
    }

    _createClass(MyClass, [{
      key: "X",
      get: function get() {
        return this.mx;
      }
    }, {
      key: "Y",
      get: function get() {
        return this.my;
      },
      set: function set(value) {
        this.my = value;
      }
    }], [{
      key: ".ctor",
      value: function ctor() {
        return new MyClass(0, 0);
      }
    }]);

    return MyClass;
  }();

  _fableCore.Util.setInterfaces(MyClass.prototype, [], "Main.Classes.MyClass");

  var Base = $exports.Base = function () {
    function Base() {
      _classCallCheck(this, Base);
    }

    _createClass(Base, [{
      key: "Add",
      value: function Add(x, y) {
        return x + y;
      }
    }, {
      key: "MemberFunc_0",
      value: function MemberFunc_0(a, b) {
        return _fableCore.List.ofArray([""]);
      }
    }]);

    return Base;
  }();

  _fableCore.Util.setInterfaces(Base.prototype, [], "Main.Classes.Base");

  var Derived = $exports.Derived = function (_Base) {
    _inherits(Derived, _Base);

    function Derived() {
      _classCallCheck(this, Derived);

      var _this = _possibleConstructorReturn(this, (Derived.__proto__ || Object.getPrototypeOf(Derived)).call(this));

      return _this;
    }

    _createClass(Derived, [{
      key: "Sub",
      value: function Sub(x, y) {
        return x - y;
      }
    }]);

    return Derived;
  }(Base);

  _fableCore.Util.setInterfaces(Derived.prototype, [], "Main.Classes.Derived");

  var Derived2 = $exports.Derived2 = function (_Base2) {
    _inherits(Derived2, _Base2);

    function Derived2() {
      _classCallCheck(this, Derived2);

      var _this2 = _possibleConstructorReturn(this, (Derived2.__proto__ || Object.getPrototypeOf(Derived2)).call(this));

      return _this2;
    }

    _createClass(Derived2, [{
      key: "MemberFunc",
      value: function MemberFunc(x, y) {
        return _fableCore.List.ofArray(["Derived", String(x), y]);
      }
    }]);

    return Derived2;
  }(Base);

  _fableCore.Util.setInterfaces(Derived2.prototype, [], "Main.Classes.Derived2");

  return $exports;
}({});

var Interfaces = exports.Interfaces = function ($exports) {
  var Derived = $exports.Derived = function () {
    function Derived() {
      _classCallCheck(this, Derived);
    }

    _createClass(Derived, [{
      key: "MemberFunc1",
      value: function MemberFunc1(x, y) {}
    }]);

    return Derived;
  }();

  _fableCore.Util.setInterfaces(Derived.prototype, ["Main.Interfaces.IInterface1"], "Main.Interfaces.Derived");

  return $exports;
}({});

var Exceptions = exports.Exceptions = function ($exports) {
  return $exports;
}({});

var Events = exports.Events = function ($exports) {
  var myEvent = $exports.myEvent = new _fableCore.Event();
  var publishedEvent = $exports.publishedEvent = myEvent.Publish;

  _fableCore.Observable.add(function (_arg1) {
    _fableCore.String.fsFormat("Events: %A")(function (x) {
      console.log(x);
    })(_arg1);
  }, publishedEvent);

  myEvent.Trigger("Data");
  return $exports;
}({});

var UnitsOfMeasure = exports.UnitsOfMeasure = function ($exports) {
  var kg = $exports.kg = function kg() {
    _classCallCheck(this, kg);
  };

  _fableCore.Util.setInterfaces(kg.prototype, [], "Main.UnitsOfMeasure.kg");

  var m = $exports.m = function m() {
    _classCallCheck(this, m);
  };

  _fableCore.Util.setInterfaces(m.prototype, [], "Main.UnitsOfMeasure.m");

  var s = $exports.s = function s() {
    _classCallCheck(this, s);
  };

  _fableCore.Util.setInterfaces(s.prototype, [], "Main.UnitsOfMeasure.s");

  var c = $exports.c = 300000000;
  var mass = $exports.mass = 1;
  var E = $exports.E = mass * c * c;

  _fableCore.String.fsFormat("UnitsOfMeasure.E: %A")(function (x) {
    console.log(x);
  })(E);

  return $exports;
}({});

var ComputationalExpressions = exports.ComputationalExpressions = function ($exports) {
  var divideBy = $exports.divideBy = function divideBy(bottom, top) {
    return bottom === 0 ? null : ~~(top / bottom);
  };

  var divideByWorkflow = $exports.divideByWorkflow = function divideByWorkflow(init, x, y, z) {
    var a = function (top) {
      return divideBy(x, top);
    }(init);

    if (a != null) {
      var b = function (top) {
        return divideBy(y, top);
      }(a);

      if (b != null) {
        var c = function (top) {
          return divideBy(z, top);
        }(b);

        if (c != null) {
          return c;
        }
      }
    }
  };

  var good = $exports.good = divideByWorkflow(12, 3, 2, 1);
  var bad = $exports.bad = divideByWorkflow(12, 3, 0, 1);

  var MaybeBuilder = $exports.MaybeBuilder = function () {
    function MaybeBuilder() {
      _classCallCheck(this, MaybeBuilder);
    }

    _createClass(MaybeBuilder, [{
      key: "Bind",
      value: function Bind(x, f) {
        return x != null ? f(x) : null;
      }
    }, {
      key: "Return",
      value: function Return(x) {
        return x;
      }
    }]);

    return MaybeBuilder;
  }();

  _fableCore.Util.setInterfaces(MaybeBuilder.prototype, [], "Main.ComputationalExpressions.MaybeBuilder");

  var maybe = $exports.maybe = new MaybeBuilder();

  var divideByWorkflow_ = $exports["divideByWorkflow'"] = function divideByWorkflow_(init, x, y, z) {
    return function (builder_) {
      return builder_.Bind(function (top) {
        return divideBy(x, top);
      }(init), function (_arg1) {
        return builder_.Bind(function (top) {
          return divideBy(y, top);
        }(_arg1), function (_arg2) {
          return builder_.Bind(function (top) {
            return divideBy(z, top);
          }(_arg2), function (_arg3) {
            return builder_.Return(_arg3);
          });
        });
      });
    }(maybe);
  };

  var good_ = $exports["good'"] = divideByWorkflow_(12, 3, 2, 1);
  var bad_ = $exports["bad'"] = divideByWorkflow_(12, 3, 0, 1);
  return $exports;
}({});