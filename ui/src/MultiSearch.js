import React, {useState} from 'react'
import { Select } from 'antd'

const { Option } = Select

const MultiSearch = ({ placeholder, items, change, ...props }) => {
  const [selectedOptions, setSelectedOptions] = useState([]);

  const handleChange = (selectedOptions) => {
      setSelectedOptions(selectedOptions);
  };



  return (
    <>
      <Select
        mode='multiple'
        allowClear
        style={{ width: '20%' }}
        placeholder={placeholder}
        onBlur={() => change(selectedOptions)}
        onClear={() => {
          console.log('clearing')
          change([])
          console.log('opts ', selectedOptions)
        }}
        optionFilterProp='children'
        {...props}
        onChange={handleChange}
      >
        {items &&
          items.map(({ id, title, count }) => (
            <Option key={id} value={id} label={title}>
              <div className='demo-option-label-item'>
                {title} ({count})
              </div>
            </Option>
          ))}
      </Select>
    </>
  )
}

export default MultiSearch
