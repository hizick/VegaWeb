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
    function VehicleFormComponent(vehicleService) {
        this.vehicleService = vehicleService;
        this.vehicle = {
            features: [],
            contact: {}
        };
    }
    VehicleFormComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.vehicleService.getMakes().subscribe(function (data) { return _this.makes = data; });
        this.vehicleService.getFeatures().subscribe(function (data) { return _this.features = data; });
        //debugger
    };
    VehicleFormComponent.prototype.onMakeChange = function () {
        var _this = this;
        //console.log("vehicle", this.vehicle)
        var selectedMake = this.makes.find(function (m) { return m.id == _this.vehicle.makeId; });
        //console.log(selectedMake)
        this.models = selectedMake ? selectedMake.models : [];
        delete this.vehicle.modelId;
    };
    VehicleFormComponent.prototype.onFeatureToggle = function (featureId, $event) {
        if ($event.target.checked) {
            this.vehicle.features.push(featureId);
        }
        else {
            var index = this.vehicle.features.indexOf(featureId);
            this.vehicle.features.splice(index, 1);
        }
    };
    VehicleFormComponent.prototype.createVehicle = function () {
        this.vehicleService.createVehicle(this.vehicle)
            .subscribe(function (data) { return console.log(JSON.stringify(data)); });
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