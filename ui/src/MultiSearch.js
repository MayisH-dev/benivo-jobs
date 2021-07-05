import React from 'react'
import { Select } from 'antd'

const { Option } = Select

const MultiSearch = ({ placeholder, items, onChange, ...props }) => {
  const handleChange = (selected) => {
    onChange(selected)
  }
  return (
    <>
      <Select
        mode='multiple'
        allowClear
        style={{ width: '20%' }}
        placeholder={placeholder}
        onChange={handleChange}
        optionFilterProp='children'
        {...props}
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
