import { Pagination } from 'antd';

const onShowSizeChange = (current, pageSize) => {
    console.log(current, pageSize);
}

const Pager = (params) => {
    return (
        <Pagination
            {...params}
            showSizeChanger
            onShowSizeChange={onShowSizeChange}
        />);
}

export default Pager
