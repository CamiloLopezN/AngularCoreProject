import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Result} from "../models/result";

@Injectable({
  providedIn: 'root'
})

export class ClientService {

  urlApi: string = 'https://localhost:7101/api/clients/';

  constructor(private request: HttpClient) {

  }

  getClients(): Observable<Result> {
    return this.request.get<Result>(this.urlApi);
  }

}
