export function forEach<TItem=any>(iterable: TItem[]) {
    return new AwaitWrapper<TItem>(iterable)
}

export class AwaitWrapper<TItem> {
    constructor(
        private readonly iterable: TItem[]
    ) {}

    do<TRes=TItem>(callback: (item: TItem, index: number) => Promise<TRes>|any) {
        const promises = []
        for (let i = 0; i < this.iterable.length; i++) {
            promises.push(callback(this.iterable[i], i))
        }
        return Promise.all(promises)
    }
}
