Function.prototype.extend = function(parent) {
    if(arguments.length>1){
        for (var i = 1; i < arguments.length; i += 1) {
            var name = arguments[i];
            this.prototype[name] = parent.prototype[name];
        }
    }
    else {
        for(var prop in parent.prototype){
            if(parent.prototype.hasOwnProperty(prop)){
                this.prototype[prop] = parent.prototype[prop];
            }
        }
    }
    
    return this;
}

function Publisher() {}

Publisher.prototype = {
    publish: function publish(data) {
        if (!this.subscribers) {
            return;
        }
        for (var i = 0; i < this.subscribers.length; i++) {
            this.subscribers[i](data);
        }
    },
    subscribe: function subscribe(handler) {
        if (!this.subscribers) {
            this.subscribers = [];
        }
        if (typeof handler !== 'function') {
            return;
        }
        this.subscribers.push(handler);
        return this;
    },

    unsubscribe: function unsubscribe(handler) {
        if (!this.subscribers) {
            this.subscribers = [];
        }
        if (typeof handler !== 'function') {
            return;
        }
        for (var i = 0; i < this.subscribers.length; i++) {
            if (handler === subscribers[i]) {
                this.subscribers.splice(i, 1);
                i--;
            }
        }
        return self;
    }
};

function Timer(interval){
    var self = this;
    var timerId;

    self.setInterval = function(newInterval){
        interval = newInterval;
    }

    self.start = function(){        
        if(!timerId){
            timerId = setInterval(tick,interval);
        }
    }

    self.stop= function(){
        if(timerId){
            clearInterval(timerId);
            timerId = 0;
        }
    }

    function tick(){
        self.publish("tick");
    }
}

Timer.extend(Publisher);


function Person(name,age){
    var self = this;

    self.birthday = function(){
        age++;
        if(age === 21){
            self.publish("I can drink alcohol!");
        }
    }           
}

Person.extend(Publisher);