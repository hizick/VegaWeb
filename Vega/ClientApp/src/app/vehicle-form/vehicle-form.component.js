"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.VehicleFormComponent = void 0;
var core_1 = require("@angular/core");
var VehicleFormComponent = /** @class */ (function () {
    function VehicleFormComponent(vehicleService, featureService) {
        this.vehicleService = vehicleService;
        this.featureService = featureService;
        this.vehicle = {};
    }
    VehicleFormComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.vehicleService.getMakes().subscribe(function (data) { return _this.makes = data; });
        this.featureService.getFeatures().subscribe(function (data) { return _this.features = data; });
        //debugger
    };
    VehicleFormComponent.prototype.onMakeChange = function () {
        var _this = this;
        //console.log("vehicle", this.vehicle)
        var selectedMake = this.makes.find(function (m) { return m.id == _this.vehicle.make; });
        //console.log(selectedMake)
        this.models = selectedMake ? selectedMake.models : [];
    };
    VehicleFormComponent = __decorate([
        core_1.Component({
            selector: 'app-vehicle-form',
            templateUrl: './vehicle-form.component.html',
            styleUrls: ['./vehicle-form.component.css']
        })
    ], VehicleFormComponent);
    return VehicleFormComponent;
}());
exports.VehicleFormComponent = VehicleFormComponent;
//# sourceMappingURL=vehicle-form.component.js.map