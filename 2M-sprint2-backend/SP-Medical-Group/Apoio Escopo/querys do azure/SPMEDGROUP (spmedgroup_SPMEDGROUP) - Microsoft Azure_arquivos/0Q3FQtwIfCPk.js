define("_generated/Less/Viva.Controls/Controls/Forms/Viva.MultiLineTextBox.css",["module"],(function(n){"use strict";return{css:".azc-multiLineTextBox{box-sizing:border-box;vertical-align:text-top;overflow:hidden;display:flex}.azc-multiLineTextBox textarea{height:100%;width:100%;display:inline-block;box-sizing:border-box;font-size:13px;resize:none;overflow:auto;margin:0;padding:2px 8px 4px;border-style:solid;border-width:1px}.azc-multiLineTextBox-wrapper{width:100%;line-height:0}",moduleId:n.id}}));
define("Viva.Controls/Controls/Forms/Viva.MultiLineTextBox",["require","exports","Viva.Controls/Controls/Base/Viva.Base","Viva.Controls/Controls/Base/Viva.TypableControl","MsPortalImpl.Controls/Controls/Base/WidgetBindingHandler","FxInternal/Css","_generated/Less/Viva.Controls/Controls/Forms/Viva.MultiLineTextBox.css"],(function(n,t,i,r,u,f,e){"use strict";function p(n,t){return t!==null&&n!==undefined&&n!==null&&n.length>t?n.slice(0,t):n}var o,s;Object.defineProperty(t,"__esModule",{value:!0});t.Widget=t.ViewModel=t.DefaultRowSize=void 0;f.injectCss(e);var a="__azc-multiLineTextBox",h="azc-inputbox azc-multiLineTextBox",c="azc-has-focus",l="azc-multiLineTextBox-disabled",v="<div class='azc-inputbox-wrapper azc-multiLineTextBox-wrapper'>"+("<textarea class='azc-textarea azc-formControl azc-input azc-validation-border "+i.autoTooltipClass+" msportalfx-font-regular' type='text' data-bind='value: data.value, valueUpdate: data.getValueUpdateTrigger(), disable: $disabled, ")+'attr: { name: $ctl._name, placeholder: data.placeholder, rows: data.rows, maxlength: data.maxLength, tabindex: $tabIndex, spellcheck: data.spellcheck().toString() }, css: { "fxs-br-error": data.validationState() === 1, "fxs-br-dirty": data.dirty(), "azc-disabled": $disabled, "azc-br-focused": data.focused() }\'><\/textarea><\/div>',y=0;t.DefaultRowSize=7;o=(function(n){function i(i){var r=n.call(this,i)||this;return r.rows=i.rows||ko.observable(t.DefaultRowSize),r.placeholder=i.placeholder||ko.observable(null),r.maxLength=i.maxLength||ko.observable(null),r.spellcheck=i.spellcheck||ko.observable(!1),r}return __extends(i,n),i})(r.ViewModel);t.ViewModel=o;s=(function(n){function t(t,i,r){var u=this,f;return r=r||{},r.viewModelType=r.viewModelType||o,u=n.call(this,t,i,r)||this,u.element.addClass(h).html(v),u._control=u.element.find("textarea"),u._name=u.options.name||a+y++,u._attachEvents(),f=u.ltm,ko.computed(f,(function(){var n=u.$disabled();u.element.toggleClass(l,n);u._control.prop("disabled",n).attr({"aria-disabled":n,readonly:n,"aria-readonly":n})})),ko.computed(f,(function(){var n=p(u.options.value(),u.options.maxLength());n!==u.options.value()&&u.options.value(n)})),u._bindDescendants(),u._afterCreate(),u._supportsFocus(!0),u}return __extends(t,n),t.prototype.dispose=function(){this._checkExistsOrRegisterDestroyId(n.prototype.dispose)||(this._cleanElement(h,l),n.prototype.dispose.call(this))},Object.defineProperty(t.prototype,"options",{get:function(){return this._options},enumerable:!1,configurable:!0}),t.prototype._getElementToFocus=function(){return this._control[0]},t.prototype._attachEvents=function(){var i=this,n=this.options,t=this.element;this.ltm.registerForDispose(t.setEvents(["keydown",function(t){t.which===13&&n.onEnterPressed&&t.shiftKey&&t.preventDefault()},],["keyup",function(t){if(t.which===13&&n.onEnterPressed&&t.shiftKey)n.onEnterPressed(i._control.val())},]));this.ltm.registerForDispose(this._control.setEvents(["focus",function(){n.focused(!0);t.toggleClass(c,!0)},],["blur",function(){n.focused(!1);t.toggleClass(c,!1)},]))},t})(r.Widget);t.Widget=s;ko.bindingHandlers.azcMultiLineTextBox=u.getBindingHandler(s)}))