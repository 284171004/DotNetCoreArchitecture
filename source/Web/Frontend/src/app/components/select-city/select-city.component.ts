import { Component } from "@angular/core";
import { NG_VALUE_ACCESSOR } from "@angular/forms";
import { Observable, of } from "rxjs";
import { OptionModel } from "../select/option.model";
import { AppSelectComponent } from "../select/select.component";

@Component({
    providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppSelectCityComponent, multi: true }],
    selector: "app-select-city",
    templateUrl: "../select/select.component.html"
})
export class AppSelectCityComponent extends AppSelectComponent {
    getOptions(filter: string): Observable<OptionModel[]> {
        if (!filter) {
            return of([]);
        }

        let options = new Array<OptionModel>();

        options.push(new OptionModel("City 1", "1"));
        options.push(new OptionModel("City 2", "2"));
        options.push(new OptionModel("City 3", "3"));

        options = options.filter((option) => option.value === filter);

        return of(options);
    }
}
