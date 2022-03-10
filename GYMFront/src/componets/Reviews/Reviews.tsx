import { DetailsList, IColumn, IDetailsColumnRenderTooltipProps, IDetailsHeaderProps, IDetailsRowProps, SelectionMode } from "@fluentui/react/lib/DetailsList";

function Reviews() {
    const columns: IColumn[] = [
        { key: "client", name: "client", fieldName: "client", minWidth: 100 },
        { key: "text", name: "text", fieldName: "text", minWidth: 100 },      
        { key: "date", name: "date", fieldName: "date", minWidth: 100 }
    ];

    const items: any[] = [
        {client: "Client 1", text: "test review 1", date: "01.01.01" },
        {client: "Client 2", text: "test review 2", date: "02.02.02" },
        {client: "Client 3", text: "test review 3", date: "03.03.03" },
        {client: "Client 4", text: "test review 4", date: "04.04.04" },
    ];

    return (        
        <DetailsList columns={columns} items={items} />
    )
}

export default Reviews;