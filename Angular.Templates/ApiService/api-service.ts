// npm Packages
import { Injectable } from $stringDelimiter$@angular/core$stringDelimiter$;
import { HttpClient } from $stringDelimiter$@angular/common/http$stringDelimiter$;
import { Observable } from $stringDelimiter$rxjs$stringDelimiter$; $packageImports$

// API Services$apiImports$

// Other Services$serviceImports$

// Models$modelImports$

@Injectable({
    providedIn: $stringDelimiter$root$stringDelimiter$
})
export class $className$ {
    private readonly baseApiRoute: string = $stringDelimiter$api/$modelNameAsParameter$$stringDelimiter$;

    constructor(private http: HttpClient$constructorInjects$) { }

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
        return this.http.get<$modelName$>(`${this.baseApiRoute}/${$modelNameAsParameter$Id}`);
    }
}