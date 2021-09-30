define("Viva.Controls/Controls/Forms/Viva.OptionPicker.Component",["require","exports","Weave/DirectMode","Weave","MsPortalImpl/Weave/Components","Fx/Weave","MsPortalImpl/Weave/Util"],(function(n,t,i,r,u,f,e){"use strict";function o(t){var o=t.vm;return i(r.GetContext,{fn:function(t){var s=e.aggregateContext(t,o);return i("ul",{className:["azc-input azc-optionPicker-list",{"azc-no-border":r.composeComputation([f.toComputation(o.values)],(function(n){return!n||!n.length}))},],"aria-disabled":s.disabled,"aria-labelledby":o.label,role:"radiogroup"},i(r.ForEach,{collection:f.toComputation(o.values),fn:function(t){var h=t.item,a=f.toComputation(h.selected),v=f.toComputation(h.text),w=f.toComputation(h.description),y=e.aggregateContext(s,h,{tabIndex:h._tabindex,disabled:h.disabled}),c=y.disabled,p=y.tabIndex,l=Object.create(null);return o.radioButtonStyle||(l["fxs-portal-button-primary"]=a,l["fxs-button-default"]=r.composeComputation([a],(function(n){return!n})),l["fxs-button-disabled"]=c,l["fxs-portal-optionPicker-dirty"]=r.composeComputation([c,f.toComputation(o.dirty)],(function(n,t){return!n&&t}))),l["fxs-portal-optionPicker-disabled"]=c,l["azc-disabled"]=c,i(r.SetContext,{disabled:c,tabIndex:p},i("li",{className:["fxs-portal-border azc-optionPicker-item",l],data:h,role:"radio","aria-label":r.composeComputation([f.toComputation(h.ariaLabel)],(function(n){return(n||"").trim()||null})),"aria-checked":a,"aria-disabled":c,tabindex:p},i("input",{className:["azc-formControl azc-radio-input",{"azc-radio-noMargin":r.composeComputation([v],(function(n){return!n}))}],type:"radio",tabindex:"-1","aria-hidden":"true",name:o.name,value:r.composeComputation([f.toComputation(h.value)],(function(n){return MsPortalFx.isNullOrUndefined(n)?null:n.toString()})),disabled:c,checked:a}),i("span",{className:"azc-radio-circle"}),i("span",null,i(u.TextOrKo,{content:v,require:n}),o.radioButtonStyle?i("div",{className:"azc-radio-input-item-desc"},i(u.TextOrKo,{content:w,require:n})):null)))}}))}})}Object.defineProperty(t,"__esModule",{value:!0});t.OptionPickerInner=void 0;t.OptionPickerInner=o}));
define("MsPortalImpl.Controls/Fields/OptionsGroupField.Component",["require","exports","Weave/DirectMode","MsPortalImpl.Controls/Fields/Base/Field.ComponentBuilder","MsPortalImpl/Weave/Builder","Viva.Controls/Controls/Forms/Viva.OptionPicker.Component"],(function(n,t,i,r,u,f){"use strict";function e(n){var o=n.vm,e=n.state,s=e.labelHelper,h=r.getFieldTsxBuilder(o,s),c=h.root,l=h.container,t=new u.Builder(function(n){return i("div",__assign({className:n.className},n.attributes),n.children)}),a;return t.insertAdjacentNode("beforeend",i(f.OptionPickerInner,{vm:e.vivaOptionPickerViewModel})),t.setAttribute("id",e.controlRootId),l.insertAdjacentNode("beforeend",t),r.attachLabelAndSubLabel({vm:o,container:l,controlRoot:t,labelHelper:s}),a=c.warnOnStyleAndAttrExistence().generateFinalTsx(),{weaveNode:a,parentClassName:c.getClassName()}}Object.defineProperty(t,"__esModule",{value:!0});t.OptionsGroupFieldInner=void 0;t.OptionsGroupFieldInner=e}));
define("_generated/Less/Viva.Controls/Controls/Forms/Viva.OptionPicker.css",["module"],(function(n){"use strict";return{css:'.azc-optionPicker ul{margin:0 1px 0 0;padding:0;list-style:none}.azc-optionPicker:not(.azc-radio) li.fxs-bg-dirty{color:#fff}.fxs-bladestyle-create .msportalfx-form .azc-optionPicker li.fxs-bg-dirty{color:inherit}.azc-radio .azc-optionPicker-item{display:inline-block;padding-right:12px;position:relative}.azc-radio .azc-optionPicker-item:focus{outline-offset:0}.azc-radio .azc-radio-input{margin:1px 6px 4px 5px;opacity:0}.azc-radio .azc-radio-circle{position:absolute;left:1px;top:50%;margin-top:-9px;width:16px;height:16px;border-radius:50%;border:1px solid}.azc-radio input[type="radio"]:checked+.azc-radio-circle::after{content:"";position:absolute;top:4px;left:4px;height:8px;width:8px;border-radius:50%}.azc-radio.azc-oneItemPerLine .azc-optionPicker-item{display:flex;margin-bottom:2px}.azc-noRadio.azc-optionPicker .azc-optionPicker-list{border:1px solid #7f7f7f;border-radius:12px;padding:1px;flex-wrap:wrap}.azc-noRadio.azc-optionPicker .azc-optionPicker-list.azc-no-border{border:none}.azc-noRadio.azc-optionPicker.azc-inlineFlex .azc-optionPicker-list{display:inline-flex}.azc-noRadio .azc-optionPicker-item{min-width:46px;line-height:13px;font-size:13px;padding:2px 8px 3px;text-align:center;cursor:pointer;float:left;overflow:hidden;text-overflow:ellipsis;border-radius:10px;background-clip:padding-box;border:1px solid transparent !important}.azc-noRadio .azc-optionPicker-item .azc-radio-input{display:none}.azc-noRadio .azc-optionPicker-item.fxs-portal-selected,.azc-noRadio .azc-optionPicker-item.azc-disabled{cursor:default}.azc-noRadio .azc-optionPicker-item:focus{outline:none}.azc-noRadio .azc-optionPicker-item[aria-checked="true"]{position:relative}.azc-noRadio.azc-useFlex{width:100%}.azc-noRadio.azc-useFlex .azc-optionPicker-list{display:flex}.azc-noRadio.azc-useFlex .azc-optionPicker-item{flex:1 1 auto}.azc-noRadio::after{content:".";display:block;height:0;clear:both;visibility:hidden}.fxs-mode-light .azc-noRadio .azc-optionPicker-item:focus{border:1px solid #605e5c !important}.fxs-mode-dark .azc-noRadio .azc-optionPicker-item:focus{border:1px solid #fff !important}.azc-optionPicker-item.azc-disabled{pointer-events:none !important}.azc-fabric .azc-radio .azc-radio-input{margin-right:8px;margin-bottom:3px}.azc-fabric .azc-radio.azc-optionPicker ul{margin-left:1px}.azc-fabric .azc-radio .azc-optionPicker-item{display:inline-table;margin:0 12px 8px 0;padding:0}.azc-fabric .azc-radio .azc-optionPicker-item:hover,.azc-fabric .azc-radio .azc-optionPicker-item:active{cursor:pointer}.azc-fabric .azc-radio .azc-optionPicker-item:hover .azc-radio-input[type="radio"]:not(:checked)+.azc-radio-circle::after,.azc-fabric .azc-radio .azc-optionPicker-item:active .azc-radio-input[type="radio"]:not(:checked)+.azc-radio-circle::after{content:"";position:absolute;top:4px;left:4px;height:8px;width:8px;border-radius:50%}.azc-fabric .azc-radio .azc-radio-circle{top:9px;left:0}.azc-fabric .azc-radio .azc-radio-circle+span{display:table-cell}.azc-fabric .azc-radio.azc-oneItemPerLine .azc-optionPicker-item{display:table;margin-right:0}.azc-radio-noMargin{margin-right:0 !important}.fxs-mode-dark .azc-radio-input-item-desc{color:#a19f9d}.fxs-mode-light .azc-radio-input-item-desc{color:#605e5c}.azc-radio-horizontal.azc-optionPicker ul{display:flex;justify-content:space-around}.azc-radio-horizontal.azc-optionPicker .azc-optionPicker-list .azc-optionPicker-item{display:flex;flex-direction:column-reverse;flex:0 1 100%;align-items:center;min-width:0;text-align:center;margin-left:8px;margin-right:8px}.azc-radio-horizontal .azc-radio-circle{position:relative;margin-top:1px}',moduleId:n.id}}));
define("Viva.Controls/Controls/Forms/Viva.OptionPicker",["require","exports","Viva.Controls/Controls/Base/Viva.ItemList","MsPortalImpl.Controls/Controls/Base/WidgetBindingHandler","FxInternal/Css","_generated/Less/Viva.Controls/Controls/Forms/Viva.OptionPicker.css"],(function(n,t,i,r,u,f){"use strict";var e;Object.defineProperty(t,"__esModule",{value:!0});t.Widget=t.ViewModel=void 0;u.injectCss(f);var v=0,o="azc-optionPicker",s="azc-validation-border",h="azc-noRadio",c="azc-radio",l="azc-useFlex",y="azc-inlineFlex",p="<li class='fxs-portal-border azc-optionPicker-item' data-bind='attr:{role:$ctl._role,\"aria-label\":$ctl._ariaLabel($data),\"aria-checked\":$ctl._ariaSelected($data),\"aria-disabled\":$disabled,disabled:$disabled,tabindex:$tabIndex},css: $ctl._selectedClass($data)'><input class='azc-formControl azc-radio-input' type=radio tabindex=-1 aria-hidden='true' data-bind='css:{\"azc-radio-noMargin\":$data && !$data.text()},checked:$ctl._getItemValueString($vm.value()),value:$ctl._getItemValueString($data),attr:{name:$vm.name,disabled:$disabled}'/><span class='azc-radio-circle'><\/span><span data-bind='untrustedContent:text'><\/span><\/li>",a=(function(n){function t(t){var i=n.call(this,t)||this;return i.sizeToContent=t.sizeToContent||!1,i.radioButtonStyle=t.radioButtonStyle||!1,i.singleItemPerLine=t.singleItemPerLine||!1,i.displayStyle=MsPortalFx.initObservable(t.displayStyle),i}return __extends(t,n),t})(i.ViewModel);t.ViewModel=a;e=(function(n){function t(t,i,r){var u=this;return r=r||{},r.viewModelType=r.viewModelType||a,u=n.call(this,t,i,r)||this,t.addClass(o+" "+s+" "+(i.radioButtonStyle?c:h)),t.addClass(u.options.sizeToContent?y:l),i.singleItemPerLine&&t.addClass("azc-oneItemPerLine"),i.displayStyle.subscribeAndRun(u.ltm,(function(n){t.toggleClass("azc-radio-horizontal",n===1)})),u._afterCreate(),u}return __extends(t,n),t.prototype.dispose=function(){this._checkExistsOrRegisterDestroyId(n.prototype.dispose)||(this._cleanElement(o,l,c,h,s),n.prototype.dispose.call(this))},Object.defineProperty(t.prototype,"options",{get:function(){return this._options},enumerable:!1,configurable:!0}),t.prototype._setName=function(){this.options.name||(this.options.name="__azc-optionPicker"+v++)},t.prototype._setRole=function(){this._role="radio";this._roleGroup="radiogroup"},t.prototype._attachItemTemplate=function(){return p},t.prototype._getItemValueString=function(n){return n?MsPortalFx.isNullOrUndefined(n.value())?null:n.value().toString():null},t.prototype._selectedClass=function(n){var t=this;return ko.pureComputed((function(){var i=[];return t.options.radioButtonStyle||(n.selected()?i.push("fxs-portal-button-primary"):i.push("fxs-button-default"),n.disabled()||t.options.disabled()?i.push("fxs-button-disabled"):t.options.dirty()&&i.push("fxs-portal-optionPicker-dirty")),(n.disabled()||t.options.disabled())&&i.push("fxs-portal-optionPicker-disabled azc-disabled"),i.join(" ")}))},t})(i.Widget);t.Widget=e;ko.bindingHandlers.azcOptionPicker=r.getBindingHandler(e)}));
define("MsPortalImpl.Controls/Fields/OptionsGroupField",["require","exports","Viva.Controls/Controls/Base/ValidationPlacements/Viva.Css","Viva.Controls/Controls/Base/ValidationPlacements/Viva.DockedBalloon","Viva.Controls/Controls/Base/Viva.ItemList","Viva.Controls/Controls/Forms/Viva.OptionPicker","MsPortalImpl.Controls/Fields/Base/Field","MsPortalImpl.Controls/Fields/OptionsGroupField.Component","MsPortalImpl/Weave/Util"],(function(n,t,i,r,u,f,e,o,s){"use strict";function y(n){return n.hasOwnProperty("items")}var h,c;Object.defineProperty(t,"__esModule",{value:!0});t.OptionsGroupField=t.Widget=t.WidgetUIState=t.InnerTsxComponent=void 0;var l=r.DockedBalloon,a="azc-optionsGroupField",v="fxc-OptionsGroupField";t.InnerTsxComponent=o.OptionsGroupFieldInner;h=(function(n){function t(t){var r=n.call(this,t)||this,i=t.vm,e=r.vivaOptionPickerViewModel=new f.ViewModel({ltm:r._ltm,sizeToContent:i.sizeToContent,radioButtonStyle:i.radioButtonStyle,singleItemPerLine:i.singleItemPerLine,displayStyle:MsPortalFx.initObservable(i.displayStyle)});return i.options.subscribeAndRun(r._ltm,(function(n){var h=n?n.length:0,f=new Array(h),o,c=i._msPortalFxWidgetValue(),r,s,t;if(n)for(r=n.length-1;r>=0;r--)s=n[r],t=new u.ItemValue(null,null),t.populateFromObject(s),f[r]=t,o||c!==t.value()?t.selected()&&t.selected(!1):(o=t,e.value(t),t.selected()||t.selected(!0));e.values(f)})),r}return __extends(t,n),t})(e.WidgetUIState);t.WidgetUIState=h;c=(function(n){function t(t,i,r,u){return n.call(this,t,i,r,u)||this}return __extends(t,n),t.prototype._initializeField=function(){n.prototype._initializeField.call(this);this.element.addClass(a).addClass(v);this.element.toggleClass("azc-fabric",this.options.radioButtonStyle&&y(this.options));this.optionsGroupFieldInit()},t.prototype.dispose=function(){var t=this._optionPickerWidget;t&&(t.dispose(),t=null);this._cleanElement(a,v);n.prototype.dispose.call(this)},Object.defineProperty(t.prototype,"validatableViewModel",{get:function(){return this.state.vivaOptionPickerViewModel},enumerable:!1,configurable:!0}),Object.defineProperty(t.prototype,"validatableWidget",{get:function(){return this._optionPickerWidget},enumerable:!1,configurable:!0}),t.prototype._createLabelAndSubLabel=function(){this._attachAriaBindings({ariaLabel:this.options.ariaLabel})},t.prototype.optionsGroupFieldInit=function(){var n=this.ltm,t=this.state.vivaOptionPickerViewModel,u=t.validationPlacements,r;u.push(new i.Css(n),new l(this._diContainer,n,l.defaultOptions));r=$(this.element[0].querySelector("#"+this.state.controlRootId));this.linkOptionsGroupViewModels();this._addWidget(this._optionPickerWidget=new f.Widget(r,t,{weaveContext:this.weaveContext}));this.setupValidationBindings()},t.prototype.linkOptionsGroupViewModels=function(){var t=this,n=this.state.vivaOptionPickerViewModel,r=this.options,i=this.ltm;r._msPortalFxWidgetValue.subscribe(i,(function(i){if(!n.value()||n.value().value()!==i){var r=t.getOptionGroupWidgetValue(i,n.values());n.value(r)}}));n.value.subscribe(i,(function(n){if(n){var i=n&&n.value();t.options._msPortalFxWidgetValue()!==i&&t.options._msPortalFxWidgetValue(i)}}));this.linkValidatableControlViewModels()},t.prototype.getOptionGroupWidgetValue=function(n,t){return t.first((function(t){return t&&t.value()===n}))},t.flightNewRender=!0,t})(e.FieldWidget);t.Widget=c;t.OptionsGroupField=s.createControlComponent({widgetCtor:c,widgetUIStateCtor:h,innerComponent:o.OptionsGroupFieldInner})}))