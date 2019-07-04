import { Input, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { AppBaseComponent } from "../base/base.component";
import { OptionModel } from "./option.model";

export abstract class AppSelectComponent extends AppBaseComponent<any> implements OnInit {
    @Input() child!: AppSelectComponent;

    options = new Array<OptionModel>();

    abstract getOptions(filter: string | undefined): Observable<OptionModel[]>;

    ngOnInit(): void {
        this.load();
    }

    clearOptions() {
        this.options = new Array<OptionModel>();
    }

    clearNgModel() {
        this.ngModel = null;
    }

    change() {
        if (!this.child) {
            return;
        }

        let child = this.child;

        while (child) {
            child.clearOptions();
            child.clearNgModel();
            child = child.child;
        }

        this.child.load(this.ngModel);
    }

    load(filter?: string | undefined) {
        this.getOptions(filter).subscribe((options: OptionModel[]) => {
            this.options = options;
        });
    }

    writeValueChanged(value: any): void {
        if (!this.child) {
            return;
        }

        this.child.load(value);
    }
}
