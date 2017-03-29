define('app',['exports', 'aurelia-http-client', 'aurelia-framework'], function (exports, _aureliaHttpClient, _aureliaFramework) {
    'use strict';

    Object.defineProperty(exports, "__esModule", {
        value: true
    });
    exports.App = undefined;

    function _classCallCheck(instance, Constructor) {
        if (!(instance instanceof Constructor)) {
            throw new TypeError("Cannot call a class as a function");
        }
    }

    var _dec, _class;

    var App = exports.App = (_dec = (0, _aureliaFramework.inject)(_aureliaHttpClient.HttpClient), _dec(_class = function () {
        function App(httpClient) {
            _classCallCheck(this, App);

            this.httpClient = httpClient;
            this.field = [];
            this.l = '0px';
        }

        App.prototype.attached = function attached() {
            var _this = this;

            return this.httpClient.createRequest(this.getServer()).asGet().send().then(function (httpResponse) {
                var newUrl = 'http://192.168.161.41:5000/api/ant/next/' + JSON.parse(httpResponse.response);
                return newUrl;
            }).then(function (newUrl) {
                setInterval(function () {

                    return _this.httpClient.createRequest(newUrl).asGet().send().then(function (httpRes) {
                        var board = JSON.parse(httpRes.response).board;
                        _this.field = board;

                        _this.field = _this.field.reduce(function (total, elem) {
                            return total.concat(elem);
                        });

                        _this.l = Math.sqrt(_this.field.length) * 68 + 'px';
                    });
                }, 3000);
            });
        };

        App.prototype.getServer = function getServer() {
            return 'http://192.168.161.41:5000/api/ant/init/10/3,3/n';
        };

        return App;
    }()) || _class);
});
define('environment',["exports"], function (exports) {
  "use strict";

  Object.defineProperty(exports, "__esModule", {
    value: true
  });
  exports.default = {
    debug: true,
    testing: true
  };
});
define('main',['exports', './environment'], function (exports, _environment) {
  'use strict';

  Object.defineProperty(exports, "__esModule", {
    value: true
  });
  exports.configure = configure;

  var _environment2 = _interopRequireDefault(_environment);

  function _interopRequireDefault(obj) {
    return obj && obj.__esModule ? obj : {
      default: obj
    };
  }

  Promise.config({
    warnings: {
      wForgottenReturn: false
    }
  });

  function configure(aurelia) {
    aurelia.use.standardConfiguration().feature('resources');

    if (_environment2.default.debug) {
      aurelia.use.developmentLogging();
    }

    if (_environment2.default.testing) {
      aurelia.use.plugin('aurelia-testing');
    }

    aurelia.start().then(function () {
      return aurelia.setRoot();
    });
  }
});
define('resources/index',["exports"], function (exports) {
  "use strict";

  Object.defineProperty(exports, "__esModule", {
    value: true
  });
  exports.configure = configure;
  function configure(config) {}
});
define('text!app.html', ['module'], function(module) { module.exports = "<template>\n    <require from=\"./resources/ants.css\" ></require>\n    <div style=\"width:${l}; height:${l}\"class=\"field\">\n        <template repeat.for=\"box of field\">\n                <div if.bind=\"box === 's'\" class=\"box black\"></div>\n                <div if.bind=\"box === 'w'\" class=\"box white\"></div>\n                <div if.bind=\"box === 'ns'\" class=\"box black north\">\n\n                </div>\n                <div if.bind=\"box === 'nw'\" class=\"box north white\">\n\n                </div>\n                <div if.bind=\"box === 'ws'\" class=\"box west black\">\n\n                </div>\n                <div if.bind=\"box === 'ww'\" class=\"box west white\">\n\n                </div>\n                <div if.bind=\"box === 'os'\" class=\"box east black\">\n\n                </div>\n                <div if.bind=\"box === 'ow'\" class=\"box east white\"></div>\n                <div if.bind=\"box === 'ss'\" class=\"box south black\"></div>\n                <div if.bind=\"box === 'sw'\" class=\"box south white\"></div>\n        </template>\n    </div>\n\n</template>\n"; });
define('text!resources/ants.css', ['module'], function(module) { module.exports = ".field {\n    background-color:red,\n}\n\n.row {\n  vertical-align: top;\n}\n\n.box {\n  display: inline-block;\n  outline: 2px solid #000000;\n  width: 64px;\n  height: 64px;\n}\n\n.black {\n   background-color: #444444;\n}\n\n.white {\n   background-color: #FFFFFF;\n}\n\n.north {\n    border-top:5px solid  red;\n        height: 59px;\n    \n}\n\n.south {\n\n\n    border-bottom:5px solid  red;\n        height: 59px;\n}\n\n.west {\n\n    border-left:5px solid  red;\n       width: 59px;\n}\n\n.east {\n\n    border-right:5px solid  red;\n    width: 59px;\n\n}"; });
//# sourceMappingURL=app-bundle.js.map