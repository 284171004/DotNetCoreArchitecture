import { Injectable } from "@angular/core";
import { forkJoin, from, Observable, of } from "rxjs";
import { map, mergeMap, switchMap, tap, toArray } from "rxjs/operators";
import { UserCity } from "./models/user.city.model";
import { UserCompany } from "./models/user.company.model";
import { User } from "./models/user.model";

@Injectable({ providedIn: "root" })
export class RxjsService {
    getUsersCitiesCompanies(): Observable<User[]> {
        return this.getUsers().pipe(
            switchMap((users) => from(users)),
            mergeMap((user) =>
                forkJoin([
                    this.getUsersCities(user.userId as number),
                    this.getUsersCompanies(user.userId as number)
                ]).pipe(
                    map((data) => ({ user, cities: data[0], companies: data[1] })),
                    tap((data) => data.user.cities = data.cities),
                    tap((data) => data.user.companies = data.companies),
                    map((data) => data.user)
                )
            ),
            toArray()
        );
    }

    private getUsers(): Observable<User[]> {
        const list = [
            { userId: 1, name: "Name 1" },
            { userId: 2, name: "Name 2" }
        ];

        return of(list);
    }

    private getUsersCities(userId: number): Observable<UserCity[]> {
        let list = [
            { userId: 1, name: "City 1" },
            { userId: 2, name: "City 2" }
        ];

        list = list.filter((user) => user.userId === userId);

        return of(list);
    }

    private getUsersCompanies(userId: number): Observable<UserCompany[]> {
        let list = [
            { userId: 1, name: "Company 1" },
            { userId: 2, name: "Company 2" }
        ];

        list = list.filter((user) => user.userId === userId);

        return of(list);
    }
}
