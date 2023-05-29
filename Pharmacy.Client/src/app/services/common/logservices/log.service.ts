import { Injectable } from '@angular/core';
import { HttpClientService } from '../http-client.service';
import { PagedCriteriaObject } from 'src/app/contracts/criteria/base/paged-criteria-object';
import { RequestResult } from 'src/app/contracts/base/request-result';
import { LogDTO } from 'src/app/contracts/log/log-dto';
import { PagedResult } from 'src/app/contracts/base/paged-result';

@Injectable({
  providedIn: 'root'
})
export class LogService {

  constructor(private httpClientService:HttpClientService) { }

  async getLogPagedList(criteria: PagedCriteriaObject, successCallBack?: () => void,errorCallBack?: (errorMessage: string) => void): Promise<RequestResult<PagedResult<LogDTO>>> {
    try {
      const result: any = await this.httpClientService.post({
        controller: "log",
        action: "getLogPagedList",
      },criteria).toPromise();
      
      return result;
    } catch (error) {
      // Handle error here
      console.error('An error occurred while fetching log data:', error);
      throw error;
    }
  }
}
