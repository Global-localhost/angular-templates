import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { $modelName$ } from "../models/$modelName$";

@Injectable()
export class $className$ {
    private readonly baseApiRoute: string = "api/$modelNameAsParameter$";

    constructor(private http: HttpClient) { }

    /**
     * Loads the full $modelName$ list.
     */
    public get$modelNamePlural$(): Observable<$modelName$[]> {
        return this.http.get<$modelName$[]>(this.baseApiRoute);
    }

    /**
     * Loads the single $modelName$ from the Id.
     * @param $modelNameAsParameter$Id
     */
    public get$modelName$($modelNameAsParameter$Id: number): Observable<$modelName$> {
        return this.http.get<$modelName$>("${this.baseApiRoute}/${$modelNameAsParameter$Id}");
    }
}