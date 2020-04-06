import { Base } from '../../Models/Base';

export interface IBaseRepository<T extends Base> {
    getAll();

    getById(Id: number);

    edit(entity: T);

    Insert(entity: T);

    Delete(id: number);
}
