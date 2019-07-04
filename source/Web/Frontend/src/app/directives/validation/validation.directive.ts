import { ElementRef, EventEmitter, HostListener, Output } from "@angular/core";

export abstract class AppValidationDirective {
    @Output() readonly ngModelChange = new EventEmitter();
    Cleave = require("cleave.js");
    cleave: any;
    selector: string;

    constructor(public el: ElementRef) {
        el.nativeElement.classList.add(el.nativeElement.name);
        this.selector = `.${el.nativeElement.name}`;
    }

    @HostListener("input", ["$event"])
    onInput($event: KeyboardEvent) {
        this.cleave.onChange();
        setTimeout(() => { this.ngModelChange.emit(($event.target as HTMLInputElement).value); }, 0);
    }

    setRawValue() {
        const formattedValue = this.cleave.getFormattedValue();
        this.ngModelChange.emit(this.cleave.getRawValue());
        setTimeout(() => { this.el.nativeElement.value = formattedValue; }, 0);
    }
}
