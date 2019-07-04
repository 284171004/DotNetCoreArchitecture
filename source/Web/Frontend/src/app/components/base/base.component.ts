import { Input } from "@angular/core";
import { ControlValueAccessor } from "@angular/forms";

export abstract class AppBaseComponent<TNgModel> implements ControlValueAccessor {
    @Input() disabled: boolean | undefined;
    @Input() name: string | undefined;
    @Input() required: boolean | undefined;

    private value!: TNgModel;
    private changed = new Array<(value: TNgModel) => void>();
    private touched = new Array<() => void>();

    abstract writeValueChanged(value: TNgModel): void;

    get ngModel(): TNgModel {
        return this.value;
    }

    set ngModel(value: TNgModel) {
        if (this.value === value) { return; }
        this.value = value;
        this.changed.forEach((fn) => fn(value));
    }

    touch() {
        this.touched.forEach((fn) => fn());
    }

    writeValue(value: TNgModel) {
        this.writeValueChanged(value);
        this.value = value;
    }

    registerOnChange(fn: (value: TNgModel) => void) {
        this.changed.push(fn);
    }

    registerOnTouched(fn: () => void) {
        this.touched.push(fn);
    }
}
