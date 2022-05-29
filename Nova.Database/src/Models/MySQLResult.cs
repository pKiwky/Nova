using System.Data.Common;

namespace Nova.MySQL.Models {

    public class MySQLResult {
        private List<MySQLRow> _rows = new();

        private int _rowsAffected;
        private ulong _insertId;

        public MySQLResult(int rowsAffected) {
            _rowsAffected = rowsAffected;
        }

        public MySQLResult(DbDataReader reader, ulong insertId) {
            while (reader.Read()) {
                var row = new MySQLRow();

                for (int i = 0; i < reader.FieldCount; i++) {
                    string value = "";
                    if (reader.IsDBNull(i) == false) {
                        value = reader.GetString(i);
                    }

                    string key = reader.GetName(i);
                    row[key] = value;
                }

                _rows.Add(row);
            }

            _insertId = insertId;
            _rowsAffected = 0;
        }

        /// <summary>
        /// Get total affected rows by this query.
        /// </summary>
        public int RowsAffected() {
            return _rowsAffected;
        }

        /// <summary>
        /// Get inserted id by this query.
        /// </summary>
        public ulong LastInsertedId() {
            return _insertId;
        }

        /// <summary>
        /// Get row by id drom rows list.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MySQLRow GetRow(int id) {
            return _rows[id];
        }

        /// <summary>
        /// Get a list with all rows fetched.
        /// </summary>
        public IReadOnlyList<MySQLRow> GetRows() {
            return _rows;
        }
    }

}