export class RequestResult<TEntity>
    {
        success?:boolean;
        message?:string;
        result?:TEntity;
        redirectUrl?:string;
    }
   