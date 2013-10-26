Function.prototype.inherit = function (parent) {
    this.prototype = new parent();
    this.prototype.constructor = parent;
};

Function.prototype.extend = function (parent) {
    for (var i = 1; i < arguments.length; i += 1) {
        var name = arguments[i];
        this.prototype[name] = parent.prototype[name];
    }
    return this;
}

// ---------- Vehicles ----------
function Vehicles(speed, propulsionUnits) {
    this.speed = speed;
    this.propulsionUnits = propulsionUnits;
    this.Accelerate = function Accelerate() {
        this.speed = this.speed + propulsionUnits.acceleration();
        return this.speed;
    }
}

// ---------- Propulsion Units ----------
function PropulsionUnits() {
}

PropulsionUnits.prototype.acceleration = function() {
}

// ---------- Wheels ----------
function Wheels(radius) {
    this.radius = radius;
}

Wheels.inherit(PropulsionUnits);

Wheels.prototype.acceleration = function () {
    var acceleration = 2 * Math.PI * this.radius;
    return acceleration;
}

// ---------- PropellingNozzles ----------
// For 'afterBurnerCondition' we have enum.
function PropellingNozzles(power, afterBurnerCondition) {
    this.power = power,
    this.afterBurnerCondition = afterBurnerCondition
}

PropellingNozzles.inherit(PropulsionUnits);

PropellingNozzles.prototype.acceleration = function () {
    if (this.afterBurnerCondition == switchCondition.ON) {
        return 2 * this.power;
    }
    else if (this.afterBurnerCondition == switchCondition.OFF) {
        return this.power;
    }
}

// ---------- Propelers ----------
function Propellers(fins, directionType) {
    this.fins = fins,
    this.directionType = directionType
}

Propellers.inherit(PropulsionUnits);

Propellers.prototype.acceleration = function () {
    if (this.directionType == spinDirection.ClockWise) {
        return this.fins;
    }
    else if (this.directionType == spinDirection.CounterClockWise) {
        return -(this.fins);
    }
}

// ---------- Vehicles types ----------
function LandVehicles(speed, propulsionUnits) {
    var numberOfWheels = 4;
    getNumberOfWheels:
    function getNumberOfWheels() {
        return numberOfWheels;
    }

    Vehicles.call(this, speed, propulsionUnits);
}

LandVehicles.inherit(Vehicles);

function AirVehicles(speed, propulsionUnits) {
    var numberOfPropelling = 1;
    this.afterBurnerCondition = afterBurnerCondition;
    getNumberOfPropelling:
    function getNumberOfPropelling() {
        return numberOfPropelling;
    }

    Vehicles.call(this, speed, propulsionUnits);
}

AirVehicles.inherit(Vehicles);

function WaterVehicles(speed, propulsionUnits, numberOfPropellers, directionType) {
    this.numberOfPropellers = numberOfPropellers,
    this.directionType = directionType

    Vehicles.call(this, speed, propulsionUnits);
}

WaterVehicles.inherit(Vehicles);

function AmphibiousVehicle(speed, landPropulsionUnits, waterPropulsionUnits, amphibiousMovementType) {
    this.amphibiousMovementType = amphibiousMovementType;
    if (this.amphibiousMovementType === amphibiousMovementType.Land) {
        Vehicles.call(this, speed, landPropulsionUnits);
    }
    else if (this.amphibiousMovementType === amphibiousMovementType.Water) {
        Vehicles.call(this, speed, waterPropulsionUnits);
    }
    
}

AmphibiousVehicle.prototype.acceleration = function () {
    if (this.amphibiousMovementType === amphibiousMovementType.Land) {
        var acceleration = 2 * Math.PI * this.radius;
        return acceleration;
    }
    else if (this.amphibiousMovementType === amphibiousMovementType.Water) {
        if (this.directionType == spinDirection.ClockWise) {
            return this.fins;
        }
        else if (this.directionType == spinDirection.CounterClockWise) {
            return -(this.fins);
        }
    }
}

AmphibiousVehicle.inherit(Vehicles);
AmphibiousVehicle.extend(LandVehicles);
AmphibiousVehicle.extend(WaterVehicles);

// ---------- Enums ----------
switchCondition = {
    ON: 'on',
    OFF: 'off'
}

spinDirection = {
    ClockWise: 'ClockWise',
    CounterClockWise: 'CounterClockWise'
}

amphibiousMovementType = {
    Land: 'land',
    Water: 'water'
}

// ---------- Tests ----------
var landVehiclesTest = new Vehicles(100, new Wheels(20));
console.log(landVehiclesTest.Accelerate()); // Vehicles speed plus 2 * PI * Wheels radius and expected result is 225.66.

var landVehiclesOtherTest = new LandVehicles(100, new Wheels(20));
console.log(landVehiclesOtherTest.Accelerate()); // Same as above

var airVehiclesTest = new Vehicles(200, new PropellingNozzles(50, switchCondition.ON));
console.log(airVehiclesTest.Accelerate()); // Vehicles speed plus 2 * PropellingNozzles power and expected result is 300.

var waterVehiclesTest = new Vehicles(300, new Propellers(100, spinDirection.ClockWise));
console.log(waterVehiclesTest.Accelerate()); // Vehicles speed plus number of fins and expected result is 400.
