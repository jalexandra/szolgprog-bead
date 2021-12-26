import App from "./app";

export const FindAll = <T>(sql: string, ...params: any[]): Promise<T> => {
    return new Promise((resolve, reject) => {
        App.sql.query(sql, params, (err, result) => {
            if (err) reject(err)
            else resolve(result as any)
        })
    })
}

export const Find = <T>(sql: string, ...params: any[]): Promise<T> => {
    return new Promise((resolve, reject) => {
        App.sql.query(sql, params, (err, result) => {
            if (err) reject(err)
            else resolve((result as any)[0])
        })
    })
}

export const Execute = (sql: string, ...params: any[]): Promise<void> => {
    return new Promise((resolve, reject) => {
        App.sql.query(sql, params, (err, result) => {
            if (err) reject(err)
            else resolve()
        })
    })
}
