import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Result} from "../models/result";

@Injectable({
  providedIn: 'root'
})

export class ProductService {

  urlApi: string = 'https://localhost:7101/api/products/';

  constructor(private request: HttpClient) {
  }

  getProducts(): Observable<Result> {
    return this.request.get<Result>(this.urlApi);
  }

}
